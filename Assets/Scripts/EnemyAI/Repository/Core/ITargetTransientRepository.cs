using System.Collections.Generic;

namespace EntityAI.Repository 
{
    public interface ITargetTransientRepository : IRepository
    {
        List<ITargetable> nearTargets { get; }
        List<ITargetable> detectedTargets { get; }
        List<ITargetable> rayHitTargets { get; }
        ITargetable currentTarget { get; }

        void AddNearTarget(ITargetable target);
        void AddDetectedTarget(ITargetable target);
        void AddRayHitTargets(ITargetable target);
        void SetCurrentTarget(ITargetable target);

        List<ITargetable> GetNearbyTargets();
        List<ITargetable> GetDetectedTargets();
        List<ITargetable> GetRaycastHitTargets();

    }
}


