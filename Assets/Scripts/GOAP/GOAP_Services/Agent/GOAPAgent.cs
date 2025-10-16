using EntityAI.GOAP.Action;
using EntityAI.GOAP.Goal;
using EntityAI.GOAP.Planer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// GOAPAgent: Управляет основным циклом "Планирование -> Исполнение".
// Является фасадом, который инжектирует все сервисы и запускает Tick.
public class GOAPAgent : MonoBehaviour, IGoapAgentExecutor // Используем интерфейс, чтобы соответствовать референсу
{
    // Public properties & State
    public IBlackboard CurrentState { get; private set; }
    public List<IGOAPAction> AvailableActions { get; set; }
    public List<IGoapGoal> AvailableGoals { get; set; }

    private GOAPPlanner _planner;
    private IContextUpdater _updater;
    private IGoalSelectionStrategy _goalStrategy;

    private Coroutine _tickCoroutine;
    private List<IGOAPAction> _currentPlan;
    private IGoapGoal _currentGoal;

    // --- Service Injection ---
    public void ServiceInitialize(GOAPPlanner planner, IContextUpdater updater, IGoalSelectionStrategy goalStrategy)
    {
        _planner = planner;
        _updater = updater;
        _goalStrategy = goalStrategy;
    }

    // --- IGoapAgentExecutor Implementation ---
    public void Initialize(IBlackboard initialState, List<IGOAPAction> actions, List<IGoapGoal> goals)
    {
        CurrentState = initialState;
        AvailableActions = actions;
        AvailableGoals = goals;
        Debug.Log("[GOAPAgent] Инициализирован. Готов к работе.");
    }

    public void StartTicking()
    {
        if (_tickCoroutine != null) StopCoroutine(_tickCoroutine);
        _tickCoroutine = StartCoroutine(MainGoapLoop());
    }

    public void StopTicking()
    {
        if (_tickCoroutine != null) StopCoroutine(_tickCoroutine);
        _tickCoroutine = null;
    }

    // --- Main Loop ---
    private IEnumerator MainGoapLoop()
    {

        while (true)
        {
            if (_currentPlan == null || _currentPlan.Count == 0 || (_currentGoal != null && _currentGoal.IsSatisfied(CurrentState)))
            {
                if (_currentGoal != null) Debug.Log($"[GOAP] Цель {_currentGoal.Name} выполнена/истекла. Перепланирование...");

                _currentGoal = _goalStrategy.SelectBestGoal(CurrentState, AvailableGoals);

                if (_currentGoal == null) { _updater.TickIdle(CurrentState, 1f); yield return new WaitForSeconds(1f); continue; }

                _currentPlan = _planner.Plan(CurrentState, _currentGoal, AvailableActions);

                if (_currentPlan == null) { _updater.TickIdle(CurrentState, 1f); yield return new WaitForSeconds(1f); continue; }

                Debug.Log($"[GOAP] План для {_currentGoal.Name}: {string.Join(" -> ", _currentPlan.Select(a => a.Name))}");
            }

            var actionToExecute = _currentPlan.First();
            _currentPlan.RemoveAt(0);

            yield return StartCoroutine(ExecuteAction(actionToExecute));

            yield return null;
        }
    }

    private IEnumerator ExecuteAction(IGOAPAction action)
    {
        Item relevantTool = action.GetRelevantTool(CurrentState);
        float quality = relevantTool?.QualityPercent ?? 100f;
        float targetDuration = action.Randomizer.CalculateEffectiveDuration(action.BaseDuration, quality);
        float elapsed = 0f;

        Coroutine actionCoroutine = StartCoroutine(action.Perform(CurrentState));

        while (elapsed < targetDuration)
        {
            float tickDuration = 1f;
            _updater.Tick(CurrentState, relevantTool, tickDuration);
            elapsed += tickDuration;

            // Safety break if the action finished early (e.g. EatAction)
            if (actionCoroutine == null) break;

            // Check for failure conditions (e.g. Energy)
            if (CurrentState.TryGet<EnergyProperty>(out var e) && e.Value <= 0)
            {
                StopTicking();
                yield break;
            }

            yield return new WaitForSeconds(tickDuration);
        }

        if (actionCoroutine != null) StopCoroutine(actionCoroutine);

        // Check for potential failure logic (simplifed here)
        // A more robust implementation would check the state before and after Perform
    }
}