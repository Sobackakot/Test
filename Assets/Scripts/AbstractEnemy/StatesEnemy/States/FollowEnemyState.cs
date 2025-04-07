using EnemyAi;
using State; 
using UnityEngine;

public class FollowEnemyState : EnemyStateBase
{
    public FollowEnemyState(
         
        IEnemyFollowTarget followTarget,
        IEnemyLoockTarget loockTarget ) 

        : base(null, null, null, null, null, followTarget,loockTarget,null)
    {
    }

    public override void EnterState()
    {
        followTarget.isFollowTarget = true;
        loockTarget.isLoockTarget = true;
    }

    public override void ExitState()
    {
        followTarget.isFollowTarget = false;
        loockTarget.isLoockTarget = false;
    }

    public override void UpdateState()
    {
        loockTarget.LoockTarget();
        followTarget.FollowTarget(); 
    }
}
