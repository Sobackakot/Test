using EntityAI.Behaviour;
using EntityAI.Components;
using EntityAI.Config;
using EntityAI.Context;
using EntityAI.Planer;
using EntityAI.React;
using EntityAI.Repository;
using State.Machine;

namespace EntityAI
{
    public interface IEntity: IEntityCommon
    {
        ITargetTransientRepository repository { get; }
        IContext context { get; }

        IEntityComponent components { get; }

        IEntityConfig config { get; }

        IBehaviourHandler behaviourHandler { get; }

        IStateMachine stateMachine { get; }

        IPlaner<IContext> planer { get; }

        IRepositorySubject repositorySubject { get; }

    }
    public enum EntityType
    {
        Fire,
        Freez,
        Ellectro
    }
}

