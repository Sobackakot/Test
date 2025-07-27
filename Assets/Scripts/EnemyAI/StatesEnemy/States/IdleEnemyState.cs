using EntityAI;
using EntityAI.Behaviour;
using State.Enemys;
using State.Machine;
using System.Collections.Generic;

public class IdleEnemyState : EnemyStateBase
{
    public IdleEnemyState(
        IEntity enemy, 
        IStateMachine stateMachine, 
        IBehaviourHandler behaviourHandler) : base(enemy, stateMachine, behaviourHandler)
    {
        var type = StateType.Idle;
        stateMachine.AddTransition(type, () => !enemy.context.isIdle ? StateType.Move : type);
        stateMachine.AddTransition(type, () => enemy.context.isRundomMove ? StateType.Move : type);
        stateMachine.AddTransition(type, () => enemy.context.isFollowTarget ? StateType.Follow : type);

        behaviours = new List<IBehaviourBase>()
        {
            behaviourHandler.GetBehaviour<IBehaviourIdle>(),
            behaviourHandler.GetBehaviour<IBehaviourLoockTarget>(),
            behaviourHandler.GetBehaviour<IBehaviourRandomRotate>()
        };
    }

    public override void EnterState()
    {
        foreach (var behaviour in behaviours)
            behaviour.Enter();

    }
    public override void ExitState()
    {
        foreach (var behaviour in behaviours)
            behaviour.Exit();
    }
    public override void UpdateState()
    {
        foreach (var behaviour in behaviours)
            behaviour.Update();
    }
    public override void LateUpdateState()
    {
        foreach (var behaviour in behaviours)
            behaviour.LateUpdate();
    }
    public override void FixedUpdateState()
    {
        foreach (var behaviour in behaviours)
            behaviour.FixedUpdate();
    }
}
