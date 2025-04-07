using EnemyAi;
using State; 
using UnityEngine;

public class FollowEnemyState : EnemyStateBase
{
    public FollowEnemyState(Enemy enemy) : base(enemy)
    {
    }

    public override void EnterState()
    { 
        enemy.isFollowTarget = true;
        enemy.isLoockTarget = true;
    }

    public override void ExitState()
    { 
        enemy.isFollowTarget = false;
        enemy.isLoockTarget = false;
    }

    public override void UpdateState()
    {
        enemy.TargetRotateState();
        enemy.TargetMoveState(); 
    }
}
