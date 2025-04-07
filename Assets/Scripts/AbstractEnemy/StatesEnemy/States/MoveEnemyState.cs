using EnemyAi;
using State;
using UnityEngine;
public class MoveEnemyState :  EnemyStateBase
{
    public MoveEnemyState(

        IEnemyRandoMove randomMove,
        IEnemyRandomRotate randomRotate)

        : base(null, null, null, randomMove,randomRotate, null, null, null)
    {}

    public override void EnterState()
    {
        randomMove.isRundomMove = true;
        randomRotate.isRundomRotate = true;
    }

    public override void ExitState()
    {
        randomMove.isRundomMove = false;
        randomRotate.isRundomRotate = false;
    }

    public override void UpdateState()
    {
        randomMove.RandomMove();
        randomRotate.RandomRotate();
    } 
}
