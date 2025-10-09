// GOAPPlanner: Теперь работает со списками GOAPFact
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GOAPPlanner
{
    public static Queue<GOAPAction> Plan(
         Dictionary<Type, GOAPFact> worldState,
         Dictionary<Type, GOAPFact> goalState,
         List<GOAPAction> availableActions
         )
    {
        // --- Инициализация поиска A* ---

        // OPEN list: Список узлов для исследования
        List<GOAPNode> openList = new List<GOAPNode>();

        // **НОВОЕ:** CLOSED list / Оптимизация: Словарь для отслеживания наименьшей стоимости
        // Ключ: уникальный строковый ключ состояния мира (StateKey). Значение: минимальная достигнутая Cost.
        Dictionary<string, float> bestCosts = new Dictionary<string, float>();

        GOAPNode startNode = new GOAPNode(worldState, null, null, 0);
        openList.Add(startNode);

        bestCosts[startNode.GetStateKey()] = 0f; // Начальное состояние всегда стоит 0

        // --- Поиск пути (A* Algorithm) ---

        while (openList.Count > 0)
        {
            // Находим узел с наименьшей G-Cost (RunningCost)
            GOAPNode currentNode = openList.OrderBy(n => n.RunningCost).First();

            // Удаляем его из OPEN
            openList.Remove(currentNode);

            string currentStateKey = currentNode.GetStateKey();

            // ПРОПУСК: Если мы нашли это же состояние мира (по ключу) с лучшей (меньшей) стоимостью
            // в процессе предыдущих итераций, пропускаем этот узел.
            if (bestCosts.TryGetValue(currentStateKey, out float knownCost) && knownCost < currentNode.RunningCost)
            {
                continue;
            }

            // --- 1. Проверка Цели ---
            if (CheckGoalMet(goalState, currentNode.WorldState))
            {
                Debug.Log("[GOAPPlanner]: План найден! Восстановление пути...");
                return ReconstructPlan(currentNode);
            }

            // --- 2. Расширение (Expansion) ---
            List<GOAPAction> validActions = FindValidActions(currentNode.WorldState, availableActions);

            foreach (GOAPAction action in validActions)
            {
                // Применяем эффекты действия, чтобы получить НОВОЕ состояние мира
                Dictionary<Type, GOAPFact> nextWorldState = ApplyEffects(currentNode.WorldState, action.GetEffects());

                float newCost = currentNode.RunningCost + action.cost;
                GOAPNode newNode = new GOAPNode(nextWorldState, currentNode, action, newCost);
                string newStateKey = newNode.GetStateKey();

                // Проверка: Если новое состояние уже есть и его известная стоимость ЛУЧШЕ (меньше), то пропускаем.
                if (bestCosts.TryGetValue(newStateKey, out float c) && c <= newCost)
                {
                    continue;
                }

                // Это лучший или первый раз, когда мы видим это состояние. Добавляем/Обновляем.
                bestCosts[newStateKey] = newCost;
                openList.Add(newNode);
            }
        }

        Debug.LogWarning("[GOAPPlanner]: Невозможно составить план! Цель недостижима.");
        return null;
    }
    // --- НОВЫЙ ВСПОМОГАТЕЛЬНЫЙ МЕТОД ---
    // Применяет эффекты к копии WorldState (для симуляции шага планировщика).
    private static Dictionary<Type, GOAPFact> ApplyEffects(
        Dictionary<Type, GOAPFact> currentState,
        Dictionary<Type, GOAPFact> effects)
    {
        // Глубокое копирование текущего состояния для безопасной симуляции
        Dictionary<Type, GOAPFact> nextState = new Dictionary<Type, GOAPFact>(currentState);

        foreach (var kvp in effects)
        {
            // Эффект всегда перезаписывает или добавляет факт в состояние
            nextState[kvp.Key] = kvp.Value.Clone();
        }

        return nextState;
    }
    // --- Вспомогательные Функции (Обновлены для работы с List<GOAPFact>) ---

    private static bool CheckGoalMet(Dictionary<Type, GOAPFact> goal, Dictionary<Type, GOAPFact> world)
    {
        foreach (var kvp in goal)
        {
            Type requiredType = kvp.Key;
            GOAPFact requiredFact = kvp.Value;

            // Проверка, есть ли требуемый факт в текущем состоянии мира (быстрый O(1) поиск по Type!)
            if (!world.TryGetValue(requiredType, out GOAPFact worldFact))
            {
                // Если факт требуется, но его нет, цель не достигнута.
                return false;
            }

            // Используем строго типизированный IsMatch для сравнения значений
            if (!requiredFact.IsMatch(worldFact))
            {
                return false; // Значения не совпадают
            }
        }
        return true;
    }


    private static List<GOAPAction> FindValidActions(Dictionary<Type, GOAPFact> worldState, List<GOAPAction> allActions)
    {
        List<GOAPAction> validActions = new List<GOAPAction>();

        foreach (GOAPAction action in allActions)
        {
            bool canRun = true;
            Dictionary<Type, GOAPFact> actionPreconditions = action.GetPreconditions();

            foreach (var kvp in actionPreconditions)
            {
                Type requiredType = kvp.Key;
                GOAPFact requiredFact = kvp.Value;

                // Проверяем, существует ли факт в мире
                if (!worldState.TryGetValue(requiredType, out GOAPFact worldFact))
                {
                    canRun = false;
                    break;
                }

                // Проверяем, совпадает ли значение
                if (!requiredFact.IsMatch(worldFact))
                {
                    canRun = false;
                    break;
                }
            }

            // Добавляем CheckProceduralPrecondition для исполнения
            if (canRun && action.CheckProceduralPrecondition())
            {
                validActions.Add(action);
            }
        }

        return validActions;
    }


    // Восстановление плана (идет от цели к началу и инвертирует)
    private static Queue<GOAPAction> ReconstructPlan(GOAPNode goalNode)
    {
        List<GOAPAction> planList = new List<GOAPAction>();
        GOAPNode currentNode = goalNode;

        while (currentNode.Action != null)
        {
            planList.Add(currentNode.Action);
            currentNode = currentNode.Parent;
        }

        // Инвертируем список, чтобы получить правильный порядок
        planList.Reverse();
        return new Queue<GOAPAction>(planList);
    }

}