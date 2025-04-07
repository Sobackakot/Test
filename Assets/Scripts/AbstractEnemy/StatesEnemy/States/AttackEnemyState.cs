using EnemyAi;
using State;
using UnityEngine;

public class AttackEnemyState : EnemyStateBase
{
    public AttackEnemyState( 

        IEnemyFollowTarget followTarget, 
        IEnemyLoockTarget loockTarget, 
        IEnemyAttackTarget attackTarget) 

        : base(null, null,null, null, null, followTarget,loockTarget, attackTarget)
    {
    }

    public override void EnterState()
    {
        attackTarget.isAttackTarget = true;
    }

    public override void ExitState()
    {
        attackTarget.isAttackTarget =false;
    }

    public override void UpdateState()
    {
        attackTarget.AttackTarget();
        followTarget.FollowTarget();
        loockTarget.LoockTarget();
    }
}
 