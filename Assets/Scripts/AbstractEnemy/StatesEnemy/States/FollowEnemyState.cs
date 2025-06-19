using EnemyAI;
using EnemyAI.Behaviour;
using State.Enemys;
using State.Machine;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemyState : EnemyStateBase
{
    public FollowEnemyState(
        Enemy enemy, 
        IStateMachine stateMachine, 
        IBehaviourHandler behaviourHandler) : base(enemy, stateMachine, behaviourHandler)
    {
        var type = StateType.Follow;
        stateMachine.AddTransition(type, () => !enemy.context.isFollowTarget ? StateType.Idle : type);
        behaviours = new List<IBehaviourBase>()
        { 
            behaviourHandler.GetBehaviour<IBehaviourFollowTarget>(),
            behaviourHandler.GetBehaviour<IBehaviourLoockTarget>()
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
