using System.Collections.Generic;
using UnityEngine;

namespace EntityAI.Repository
{
    public class TargetSingleRepository : MonoBehaviour, ITargetSingleRepository
    {
        public List<ITargetable> _activeTargets =new();
        public List<ITargetable> activeTargets => _activeTargets;

        public void Enter()
        { 
        }

        public void Exit()
        { 
        }

        public List<ITargetable> GetTargets() => activeTargets;

        public void RegisterTarget(ITargetable target)
        {
            if (!activeTargets.Contains(target))
            {
                activeTargets?.Add(target); 
            }
        }

        public void UnregisterTarget(ITargetable target)
        {
            if (activeTargets.Contains(target))
            {
                activeTargets?.Remove(target);
            }
        }
    }

}
