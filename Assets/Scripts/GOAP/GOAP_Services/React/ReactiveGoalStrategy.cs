using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// ReactiveGoalStrategy: Реализует логику выбора цели с динамическими приоритетами 
// (на основе состояния мира) и стратегией пакетного накопления (Batch Stockpile).
public class ReactiveGoalStrategy : IGoalSelectionStrategy
{
    private const int StockpileBatchSize = 10;

    public IGoapGoal SelectBestGoal(IBlackboard currentState, IEnumerable<IGoapGoal> goals)
    {
        var orderedGoals = goals
            .Select(g => new
            {
                Goal = g,
                DynamicPriority = g.Priority + CalculateDynamicBonus(g, currentState)
            })
            .OrderByDescending(x => x.DynamicPriority)
            .ToList();

        foreach (var item in orderedGoals)
        {
            var goal = item.Goal;

            if (goal is StockpileGoal sp)
            {
                var subGoal = ProcessStockpileGoal(sp, currentState);
                if (subGoal != null) return subGoal;
                continue;
            }

            if (goal.IsSatisfied(currentState)) continue;

            return goal;
        }

        return null;
    }

    private float CalculateDynamicBonus(IGoapGoal goal, IBlackboard bb)
    {
        if (goal is EatGoal && bb.TryGet<HungerProperty>(out var h))
        {
            return Mathf.Clamp01((h.Value - 30f) / 70f) * 2f;
        }
        return 0f;
    }

    private IGoapGoal ProcessStockpileGoal(StockpileGoal goal, IBlackboard bb)
    {
        int currentReserve = bb.TryGet<FoodReserveProp>(out var frNow) ? frNow.Value : 0;

        if (currentReserve >= goal.Target) return null;

        int remaining = goal.Target - currentReserve;
        int batch = Mathf.Min(StockpileBatchSize, remaining);
        int subTarget = currentReserve + batch;

        return new StockpileSubGoal(goal.Priority, subTarget);
    }
}