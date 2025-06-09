 
using State.Enemys;
using State.Machine;
using EnemyAi;
using UnityEngine;
public class MoveEnemyState :  EnemyStateBase
{
    public MoveEnemyState(IStateMachine stateMachine, IBehaviourHandler behaviour, Enemy enemy) 
        : base(stateMachine, behaviour, enemy)
    {
        var type = StateType.Move;
        stateMachine.AddTransition(type, () => !enemy.isRundomMove ? StateType.Idle : type);
        stateMachine.AddTransition(type, () => enemy.isIdle ? StateType.Idle : type);
        stateMachine.AddTransition(type, () => enemy.isFollowTarget ? StateType.Follow : type);
    }

    public override void EnterState() 
    { 
        behaviour.Enter();
       
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
