using EntityAI;
using EntityAI.Behaviour;
using EntityAI.Context;
using EntityAI.Planer;
using EntityAI.React;
using State.Enemys;

public class MainInitialize : ObserverContextBase<CreatorActionType>
{
    public MainInitialize(IActionSubject<CreatorActionType, IObserverContext<CreatorActionType>> subject) : base(subject)
    {
        Register(CreatorActionType.Creator, (IEntity entity) => OnCreator_InitializeEntity(entity));
        SubscribeAll();
        repositorySubject = new RepositorySubject(); 
    }
    ~MainInitialize()
    {
        UnsubscribeAll();
    }

    public IRepositorySubject repositorySubject { get; private set; }


    public void OnCreator_InitializeEntity(IEntity entity)
    {
        entity.InitializeEntityAI
            (
            repositorySubject,
            new EnemyStateContext(entity),  
            new BehaviourHandler(),
            new EntityStateMachine(),
            new Planer<IContext>());

        InitActions(entity);
        InitBehaviours(entity);
        InitStates(entity);
        entity.Initializable();
    }
     

    private void InitActions(IEntity entity)
    {
        entity.planer.RegisterAction(new EnemyMoveAction(entity));
    }

    private void InitBehaviours(IEntity entity)
    {
        var behaviourHandler = entity.behaviourHandler; 

        behaviourHandler.RegisterBehaviour<IBehaviourIdle>(new EnemyIdle(entity));  
        behaviourHandler.RegisterBehaviour<IBehaviourMove>(new EnemyMove(entity));
        behaviourHandler.RegisterBehaviour<IBehaviourRotate>(new EnemyRotate(entity)); 
        behaviourHandler.RegisterBehaviour<IBehaviourRandomMove>(new EnemyRandomMove(entity));
        behaviourHandler.RegisterBehaviour<IBehaviourRandomRotate>(new EnemyRandomRotate(entity)); 
        behaviourHandler.RegisterBehaviour<IBehaviourFollowTarget>(new EnemyFollowTarget(entity));
        behaviourHandler.RegisterBehaviour<IBehaviourLoockTarget>(new EnemyLoockTarget(entity)); 
        behaviourHandler.RegisterBehaviour<IBehaviourAttackTarget>(new EnemyAttackTarget(entity));
    }
    public void InitStates(IEntity entity)
    {
        var stateMachine = entity.stateMachine;
        var behaviourHandler = entity.behaviourHandler;

        stateMachine.RegisterState(StateType.Idle, new IdleEnemyState(entity));
        stateMachine.RegisterState(StateType.Move, new MoveEnemyState(entity));
        stateMachine.RegisterState(StateType.Follow, new FollowEnemyState(entity));
        stateMachine.RegisterState(StateType.Follow, new AttackEnemyState(entity));
    }
}
