using EntityAI;
using EntityAI.Behaviour;
using System.Collections.Generic;

namespace EntityAI.Repository
{
    public interface IBehaviourRepository  
    {
        Dictionary<IEntity, IBehaviourHandler> behaviourHandlers { get; } 
        void RegisterBehaviour(IEntity enemy,IBehaviourHandler handler);
        void UnregisterBehaviour(IEntity enemy);
    }
}