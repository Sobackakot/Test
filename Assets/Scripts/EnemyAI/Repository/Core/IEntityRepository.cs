using EnemyAI.Behaviour;
using EnemyAI.Planer;
using Entity;
using State.Machine;
using System.Collections.Generic;
using EnemyAI.Context;

namespace EnemyAI.Repository 
{
    public interface IEntityRepository<Entity> where Entity : class, IEntity
    {
        Dictionary<IEntity, IStateMachine> stateMachines { get; }

        Dictionary<IEntity, IBehaviourHandler> behaviourHandlers { get; }

        Dictionary<IEntity, IPlaner<IContext>> planersAction { get; }

        Dictionary<string, IEntity> entities { get; }

        void RegistryEntity(string id, Entity enemy);

        void UnRegistryEnemy(string id, Entity enemy);

        void Tick();
        void LateTick();
        void FixedTick();
    }
}


