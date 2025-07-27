using EntityAI.Behaviour;
using EntityAI.Planer;
using Entity;
using State.Machine;
using System.Collections.Generic;
using EntityAI.Context;

namespace EntityAI.Repository 
{
    public interface IEntityRepository
    {
        Dictionary<IEntity, IStateMachine> stateMachines { get; }

        Dictionary<IEntity, IBehaviourHandler> behaviourHandlers { get; }

        Dictionary<IEntity, IPlaner<IContext>> planersAction { get; }

        Dictionary<string, IEntity> entities { get; }

        void RegistryEntity(string id, IEntity enemy);

        void UnRegistryEnemy(string id, IEntity enemy);

        void Tick();
        void LateTick();
        void FixedTick();
    }
}


