using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using Zenject;

// GOAPAgent: Управляющий класс.
public class GOAPAgent  
{ 
    public  GOAPAgent(
       List<GOAPAction> actions,
       List<GOAPGoal> goals,
       List<WorldFactSensor> sensors,
       AgentContext context,
       IGoalSelectionStrategy goalSelector)
    {
        availableActions = actions;
        availableGoals = goals;
        _goalSelector = goalSelector;
        // **УЛУЧШЕНИЕ:** Инициализация всех сенсоров
        // Получаем все компоненты WorldFactSensor, прикрепленные к Агенту или его дочерним объектам.
        allSensors = sensors;

        // Инициализация контекста и плана
        if (Context == null) Context = context;
        currentPlan = new Queue<GOAPAction>();

        // Проверка, что сенсоры найдены, иначе GatherWorldState() не будет работать.
        if (allSensors == null || allSensors.Count == 0)
        {
            Debug.LogError("GOAPAgent: Не найдено ни одного WorldFactSensor! Сбор состояния мира невозможен.");
        }
    }
    // --- Ссылки на систему --- 
    public AgentContext Context;

    // --- Управление Планом ---
    private Queue<GOAPAction> currentPlan;
    private GOAPAction currentAction;

    // Все доступные действия и цели
    private List<GOAPAction> availableActions;
    private List<GOAPGoal> availableGoals;

    // Текущее состояние мира для отладки
    private Dictionary<Type, GOAPFact> currentWorldState;
    private List<WorldFactSensor> allSensors;

    // --- Состояние для Отладки --- 
    public string currentGoalName = "None";
    public string currentActionName = "None";

  

    private IGoalSelectionStrategy _goalSelector;
    

    public void Tick()
    {
        // 1. Проверка необходимости нового плана
        if (currentPlan.Count == 0 || (currentAction != null && currentAction.IsActionFinished()))
        {
            if (currentAction != null)
            {
                currentAction.Reset();
                currentAction = null;
            }

            FindBestPlanAndExecute();
        }

        // 2. Исполнение плана
        if (currentPlan.Count > 0)
        {
            ExecutePlan();
        }

        // Обновление отладочных полей
        currentActionName = currentAction != null ? currentAction.GetActionName() : "Idle/Planning...";
    }

    // --- Методы Планирования ---

    private void FindBestPlanAndExecute()
    {
        // 1. Собираем актуальный WorldState
        currentWorldState = GatherWorldState();

        // 2. Выбираем лучшую цель
        GOAPGoal bestGoal = SelectBestGoal(currentWorldState);

        if (bestGoal == null)
        {
            currentGoalName = "None (All goals achieved)";
            return; // Нет актуальных целей
        }

        currentGoalName = bestGoal.GetGoalName();

        // 3. Вызываем Планировщик!
        Debug.Log($"[GOAPAgent]: Выбрана цель: {currentGoalName}. Ищем план...");

        // Здесь происходит магия A*
        Queue<GOAPAction> plan = GOAPPlanner.Plan(
            currentWorldState,
            bestGoal.GetGoalState(),
            availableActions
        );

        if (plan != null && plan.Count > 0)
        {
            currentPlan = plan;
            Debug.Log($"[GOAPAgent]: План найден! Действий: {currentPlan.Count}");
        }
        else
        {
            Debug.LogWarning($"[GOAPAgent]: Невозможно составить план для цели {currentGoalName}.");
        }
    }

    private GOAPGoal SelectBestGoal(Dictionary<Type, GOAPFact> worldState)
    {
        // Если стратегия не найдена, возвращаем null, чтобы избежать ошибок
        if (_goalSelector == null) return null;

        // Вся сложная логика вынесена в отдельный, легко заменяемый класс!
        return _goalSelector.SelectBestGoal(availableGoals, worldState);
    }

    private Dictionary<Type, GOAPFact> GatherWorldState()
    {
        var worldState = new Dictionary<Type, GOAPFact>();

        // Просто перебираем ВСЕ сенсоры и добавляем факты, если они не null.
        foreach (var sensor in allSensors)
        {
            GOAPFact sensedFact = sensor.SenseFact();

            if (sensedFact != null)
            {
                // Используем строгую типизацию
                worldState.Add(sensedFact.GetType(), sensedFact);
            }
        }

        return worldState;
    }

    // --- Методы Исполнения ---

    private void ExecutePlan()
    {
        // ... (Логика ExecutePlan остается прежней)
        if (currentAction == null)
        {
            if (currentPlan.Count > 0)
            {
                currentAction = currentPlan.Dequeue();

                if (!currentAction.CheckProceduralPrecondition())
                {
                    Debug.LogError($"[GOAPAgent]: Отмена! Процедурное условие для {currentAction.GetActionName()} не выполнено. Сбрасываю план.");
                    currentPlan.Clear();
                    currentAction.Reset();
                    currentAction = null;
                    return;
                }
            }
        }

        if (currentAction != null)
        {
            if (currentAction.Perform())
            {
                currentAction.Reset();
                currentAction = null;
            }
        }
    }
}