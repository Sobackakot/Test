using EntityAI.GOAP.Goal;
using System;
using System.Collections.Generic;
using UnityEngine;

// Конкретная цель: Персонаж должен быть сыт (не голоден).
public class BeFedGoal : GOAPGoal
{
    public BeFedGoal(float priority) : base(priority)
    {
    }

    public override string Name => throw new NotImplementedException();

    public override bool IsSatisfied(IBlackboard bb)
    {
        throw new NotImplementedException();
    }
}