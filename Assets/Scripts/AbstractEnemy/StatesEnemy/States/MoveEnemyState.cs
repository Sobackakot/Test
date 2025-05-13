 
using State.Enemy;
using State.Machine;
using UnityEngine;
public class MoveEnemyState :  EnemyStateBase
{
    public MoveEnemyState(IStateMachine stateMachine, IBehaviourHandler behaviour) : base(stateMachine, behaviour)
    {
    }

    public override void EnterState() 
    { 
        behaviour.Enter();
        var type = StateType.Move;
        stateMachine.AddTransition(type, () => !behaviour.enemy.isRundomMove ? StateType.Idle : type);
        stateMachine.AddTransition(type, () => behaviour.enemy.isIdle ? StateType.Idle : type);
        stateMachine.AddTransition(type, () => behaviour.enemy.isFollowTarget ? StateType.Follow : type);
    }
    public override void ExitState()
    { 
        behaviour.Exit();
    }
    public override void UpdateState()
    {
        behaviour.Update();
    }
    public override void LateUpdateState()
    {
        behaviour.LateUpdate();
    }

    public override void FixedUpdateState()
    {
        behaviour.FixedUpdate();
    }
}
