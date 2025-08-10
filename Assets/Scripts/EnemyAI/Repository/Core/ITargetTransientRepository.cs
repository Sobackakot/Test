using System.Collections.Generic;

namespace EntityAI.Repository 
{
    public interface ITargetTransientRepository : IRepository
    {
        List<ITargetable> nearTargets { get; }
        List<ITargetable> detectedTargets { get; }
        List<ITargetable> rayHitTargets { get; }
        ITargetable CurrentTarget { get; }
    }
}


