using EntityAI;
using EntityAI.Behaviour;
using EntityAI.Context;
using EntityAI.Planer;
using EntityAI.React;
using State.Enemys;
using State.Machine;

public class MainPoint : SabjectAction<EntityActionType, IObserverContext<EntityActionType>>
{ 

    private IStateMachine stateMachine;
    private IBehaviourHandler behaviourHandler;
    private IPlaner<IContext> planer;
  
    public void InitializeEntity(IEntity entity)
    { 
        InvokeAction(EntityActionType.EntityReg, entity.config.entityId, entity);
        InitActions(planer);
        InitBehaviours(entity, behaviourHandler);
        InitStates(entity, stateMachine);
         
        stateMachine.SetState(StateType.Idle);
    }
     

    private void InitActions(IPlaner<IContext> planer)
    {
        planer.RegisterAction(new EnemyMoveAction(new EnemyStateHandler()));
    }
    private void InitBehaviours(IEntity enemy, IBehaviourHandler behHandler)
    {
        behHandler.RegisterBehaviour<IBehaviourIdle>(new EnemyIdle(enemy));

        behHandler.RegisterBehaviour<IBehaviourMove>(new EnemyMove(enemy));
        behHandler.RegisterBehaviour<IBehaviourRotate>(new EnemyRotate(enemy));

        behHandler.RegisterBehaviour<IBehaviourRandomMove>(new EnemyRandomMove(enemy));
        behHandler.RegisterBehaviour<IBehaviourRandomRotate>(new EnemyRandomRotate(enemy));

        behHandler.RegisterBehaviour<IBehaviourFollowTarget>(new EnemyFollowTarget(enemy));
        behHandler.RegisterBehaviour<IBehaviourLoockTarget>(new EnemyLoockTarget(enemy));

        behHandler.RegisterBehaviour<IBehaviourAttackTarget>(new EnemyAttackTarget(enemy));
    }
    public void InitStates(IEntity enemy, IStateMachine stateHandler)
    {
        stateHandler.RegisterState(StateType.Idle, new IdleEnemyState(enemy, stateHandler, new BehaviourHandler()));
        stateHandler.RegisterState(StateType.Move, new MoveEnemyState(enemy, stateHandler, new BehaviourHandler()));
        stateHandler.RegisterState(StateType.Follow, new FollowEnemyState(enemy, stateHandler, new BehaviourHandler()));
        stateHandler.RegisterState(StateType.Follow, new AttackEnemyState(enemy, stateHandler, new BehaviourHandler()));
    }

    public void Tick()
    {
        //foreach (var state in stateMachines.Values)
        //{
        //    state.UpdateState();
        //}
    }

    public void LateTick()
    {
        //foreach (var state in stateMachines.Values)
        //{
        //    state.LateUpdateState();
        //}
    }

    public void FixedTick()
    {
        //foreach (var state in stateMachines.Values)
        //{
        //    state.FixedUpdateState();
        //}
        //foreach (var entity in entities.Values)
        //{
        //    planersAction[entity].UpdateContext(entity.context);
        //}
    }

}
