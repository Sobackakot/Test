using EnemyAi;
using EnemyAi.State;
using UnityEngine;
public class IdleEnemyState : EnemyStateBase
{
    public IdleEnemyState(

        IEnemyIdle idle,
        IEnemyRandomRotate randomRotate,
        IEnemyLoockTarget loockTarget) 

        : base(idle, null, randomRotate, null, loockTarget, null)
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
        idle.IdleState();
        randomRotate.RandomRotate();
        loockTarget.LoockTarget();
    }
}
