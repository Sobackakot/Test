using EnemyAi;
using EnemyAi.State; 
using UnityEngine;

public class FollowEnemyState : EnemyStateBase
{
    public FollowEnemyState(
         
        IEnemyFollowTarget followTarget,
        IEnemyLoockTarget loockTarget ) 

        : base( null, null, null, followTarget,loockTarget,null) { }
    public override void EnterState() { }
    public override void ExitState() { }
    public override void UpdateState()
    {
        loockTarget.LoockTarget();
        followTarget.FollowTarget(); 
    }
}
