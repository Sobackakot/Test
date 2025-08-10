
using System.Collections.Generic;

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

        ITargetable _CurrentTarget ;
        public ITargetable CurrentTarget => _CurrentTarget;

        public void Enter()
        { 
        }

        public void Exit()
        { 
        }
    }

}
