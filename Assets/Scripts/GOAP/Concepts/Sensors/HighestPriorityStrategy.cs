using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

// HighestPriorityStrategy: Реализует стандартный выбор по наивысшему приоритету.
public class HighestPriorityStrategy : IGoalSelectionStrategy
{
    public GOAPGoal SelectBestGoal(List<GOAPGoal> allGoals, Dictionary<Type, GOAPFact> worldState)
    {
        GOAPGoal bestGoal = null;
        float highestPriority = 0f;

        foreach (GOAPGoal goal in allGoals)
        {
            // Сначала проверяем, достигнута ли цель
            if (goal.IsGoalAchieved(worldState))
            {
                continue;
            }

            // Затем выбираем самую приоритетную
            if (goal.priority > highestPriority)
            {
                highestPriority = goal.priority;
                bestGoal = goal;
            }
        }

        return bestGoal;
    }
}