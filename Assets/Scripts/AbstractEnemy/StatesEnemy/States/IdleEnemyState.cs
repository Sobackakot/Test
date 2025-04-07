using EnemyAi;
using State;
using UnityEngine;
public class IdleEnemyState : EnemyStateBase
{
    public IdleEnemyState(

        IEnemyIdle idle,
        IEnemyRandomRotate randomRotate,
        IEnemyLoockTarget loockTarget) 

        : base(idle, null,null, null, randomRotate, null, loockTarget, null)
    {
    }

    public override void EnterState()
    {
        idle.isIdle = true; 
    }

    public override void ExitState()
    {
        idle.isIdle = false;
    }

    public override void UpdateState()
    {
        idle.IdleState();
        randomRotate.RandomRotate();
        loockTarget.LoockTarget();
    }
}
