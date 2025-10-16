using EntityAI.GOAP.Action;
using EntityAI.GOAP.Goal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityAI.GOAP.Planer
{
    public interface IGOAPPlanner  
    {
        IHeuristicStrategy heuristicStrategy { get; }
        IStateHasher hasher { get; }

        List<IGOAPAction> Plan(IBlackboard startState, IGoapGoal goal, List<IGOAPAction> availableActions, int maxBudget = 5000);
    }

}
