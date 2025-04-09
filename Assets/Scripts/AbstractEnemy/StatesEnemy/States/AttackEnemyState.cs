using EnemyAi;
using EnemyAi.State;
using UnityEngine;

public class AttackEnemyState : EnemyStateBase
{
    public AttackEnemyState( 

        IEnemyFollowTarget followTarget, 
        IEnemyLoockTarget loockTarget, 
        IEnemyAttackTarget attackTarget) 

        : base(null, null, null, followTarget,loockTarget, attackTarget)
    {
    } 
    public override void EnterState()
    { 
    }

    public override void ExitState()
    { 
    }

    public override void UpdateState()
    {
        attackTarget.AttackTarget();
        followTarget.FollowTarget();
        loockTarget.LoockTarget();
    }
}
 