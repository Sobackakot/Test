using EnemyAI;
using State.Enemys;
using State.Machine;
using UnityEngine;

public class AttackEnemyState : EnemyStateBase
{
    public AttackEnemyState(IStateMachine stateMachine, IBehaviourHandler behaviour, Enemy enemy) 
        : base(stateMachine, behaviour, enemy)
    {
        var type = StateType.Attack;
        stateMachine.AddTransition(type, () => !enemy.context.isAttackTarget ? StateType.Idle : type);
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
 