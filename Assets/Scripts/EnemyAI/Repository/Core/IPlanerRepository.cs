using EntityAI;
using EntityAI.Context;
using EntityAI.Planer;
using System.Collections.Generic;

namespace EntityAI.Repository
{
    public interface IPlanerRepository  
    { 
        Dictionary<IEntity, IPlaner<IContext>> planersAction { get; }
        void RegisterPlaner(IEntity enemy, IPlaner<IContext> planer);

        void UnregistrerPlaner(IEntity enemy);
    }
}