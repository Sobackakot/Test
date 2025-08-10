using System.Collections.Generic;

namespace EntityAI.Repository
{
    public interface ITargetSingleRepository : IRepository
    {
         List<ITargetable> activeTargets { get;  }

         void RegisterTarget(ITargetable target);
         void UnregisterTarget(ITargetable target);
         List<ITargetable> GetTargets();
    }
}