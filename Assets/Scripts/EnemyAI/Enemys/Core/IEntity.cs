using EntityAI.Behaviour;
using EntityAI.Components;
using EntityAI.Config;
using EntityAI.Context;
using EntityAI.Planer;
using State.Machine;

namespace EntityAI
{
    public interface IEntity 
    { 
        public IContext context { get; }

        public IEntityComponent components { get; }

        public IEntityConfig config { get; }

        public IBehaviourHandler behaviourHandler { get; }

        public IStateMachine stateMachine { get; }

        public IPlaner<IContext> planer { get; }
 
    }
    public enum EntityType
    {
        Fire,
        Freez,
        Ellectro
    }
}

