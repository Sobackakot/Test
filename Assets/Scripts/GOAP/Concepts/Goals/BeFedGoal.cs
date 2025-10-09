using System;
using System.Collections.Generic;
using UnityEngine;

// Конкретная цель: Персонаж должен быть сыт (не голоден).
public class BeFedGoal : GOAPGoal
{
    public BeFedGoal(AgentContext Context) : base(Context)
    {
    }

    public override void SetupGoal()
    {
        priority = 10f; // Высокий приоритет для выживания

        // Целевое состояние: IsHungryFact должно быть False.
        AddGoalFact(new IsHungryFact(false));
    }

    // Проверяем, достигнута ли цель, используя актуальное состояние мира.
    public override bool IsGoalAchieved(Dictionary<Type, GOAPFact> worldState)
    {
        // Читаем IsHungryFact из контекста (Context.IsCharacterHungry())
        return !Context.IsCharacterHungry();
    }
}