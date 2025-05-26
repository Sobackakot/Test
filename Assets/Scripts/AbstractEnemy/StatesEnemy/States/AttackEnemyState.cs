using State.Enemy;
using State.Machine;
using UnityEngine;

public class AttackEnemyState : EnemyStateBase
{
    public AttackEnemyState(IStateMachine stateMachine, IBehaviourHandler behaviour) : base(stateMachine, behaviour)
    {
        var type = StateType.Attack;
        stateMachine.AddTransition(type, () => !behaviour.enemy.isAttackTarget ? StateType.Idle : type);
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
 