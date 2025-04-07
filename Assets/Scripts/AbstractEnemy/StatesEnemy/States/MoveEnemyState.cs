using EnemyAi;
using State;
using UnityEngine;
public class MoveEnemyState :  EnemyStateBase
{
    public MoveEnemyState(Enemy enemy) : base(enemy)
    {
    }

    public override void EnterState()
    { 
        enemy.isRundomMove = true;
        enemy.isRundomRotate = true;
    }

    public override void ExitState()
    { 
        enemy.isRundomMove = false;
        enemy.isRundomRotate = false;
    }

    public override void UpdateState()
    {
        enemy.RandomRotateState();
        enemy.RandomMoveState();
    } 
}
