using EnemyAi;
using EnemyAi.State;
using UnityEngine;
public class IdleEnemyState : EnemyStateBase
{
    public IdleEnemyState(IBehaviourHandler behaviour) : base(behaviour) { }
    public override void EnterState() { }
    public override void ExitState() { }
    public override void UpdateState()
    {
        behaviour.Update();
    }
}
