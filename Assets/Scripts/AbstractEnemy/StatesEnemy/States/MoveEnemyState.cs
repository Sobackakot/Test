using EnemyAi;
using EnemyAi.State;
using UnityEngine;
public class MoveEnemyState :  EnemyStateBase
{
    public MoveEnemyState(

        IEnemyRandoMove randomMove,
        IEnemyRandomRotate randomRotate)

        : base(null, randomMove,randomRotate, null, null, null)
    {}

    public override void EnterState()
    { 
    }

    public override void ExitState()
    { 
    }

    public override void UpdateState()
    {
        randomMove.RandomMove();
        randomRotate.RandomRotate();
    } 
}
