using EnemyAi;
using State;
using UnityEngine;
public class IdleEnemyState : EnemyStateBase
{
    public IdleEnemyState(Enemy enemy) : base(enemy)
    {
    }

    public override void EnterState()
    { 
        enemy.isIdle = true; 
    }

    public override void ExitState()
    { 
        enemy.isIdle = false;
    }

    public override void UpdateState()
    {
        enemy.IdleState();   
    }
}
