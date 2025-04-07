using EnemyAi;
using State;
using UnityEngine;

public class AttackEnemyState : EnemyStateBase
{
    public AttackEnemyState(Enemy enemy) : base(enemy)
    {
    }

    public override void EnterState()
    { 
        enemy.isAttackTarget = true;
    }

    public override void ExitState()
    { 
        enemy.isAttackTarget =false;
    }

    public override void UpdateState()
    { 
        enemy.AttackState();  
    }
}
 