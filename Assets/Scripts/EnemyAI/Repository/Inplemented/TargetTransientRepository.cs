
using System.Collections.Generic;
using UnityEngine;


namespace EntityAI.Repository
{
    public class TargetTransientRepository : ITargetTransientRepository
    {
        List<ITargetable> _nearTargets =new();
        public List<ITargetable> nearTargets => _nearTargets;

        List<ITargetable> _detectedTargets =new();
        public List<ITargetable> detectedTargets => _detectedTargets;

        List<ITargetable> _rayHitTargets =new();
        public List<ITargetable> rayHitTargets => _rayHitTargets;

        ITargetable _currentTarget ;
        public ITargetable currentTarget => _currentTarget;

        public void Enter()
        { 
        }

        public void Exit()
        { 
        }

        public void AddNearTarget(ITargetable target)
        {
            if (nearTargets.Contains(target)) return;
            nearTargets.Add(target); 
        }

        public void AddDetectedTarget(ITargetable target)
        {
            if (detectedTargets.Contains(target)) return;
            nearTargets.Add(target); 
        }

        public void AddRayHitTargets(ITargetable target)
        {
            if (detectedTargets.Contains(target)) return;
            detectedTargets.Add(target); 
        }

        public void SetCurrentTarget(ITargetable target)
        {
            _currentTarget = target; 
        }

        public List<ITargetable> GetNearbyTargets()
        {
            return nearTargets;
        }
        public List<ITargetable> GetDetectedTargets()
        {
            return detectedTargets;
        }
        public List<ITargetable> GetRaycastHitTargets()
        {
            return rayHitTargets;
        }
    }

}
