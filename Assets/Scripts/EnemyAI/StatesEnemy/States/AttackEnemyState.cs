using EntityAI;
using EntityAI.Behaviour;
using State.Enemys;
using State.Machine;
using System.Collections.Generic;

public class AttackEnemyState : EnemyStateBase
{
    public AttackEnemyState(
        IEntity enemy, 
        IStateMachine stateMachine, 
        IBehaviourHandler behaviourHandler) : base(enemy, stateMachine, behaviourHandler)
    {
        var type = StateType.Attack;
        stateMachine.AddTransition(type, () => !enemy.context.isAttackTarget ? StateType.Idle : type);
        behaviours = new List<IBehaviourBase>()
        {
            behaviourHandler.GetBehaviour<IBehaviourAttackTarget>(),
            behaviourHandler.GetBehaviour<IBehaviourFollowTarget>(),
            behaviourHandler.GetBehaviour<IBehaviourLoockTarget>()
        };
    }

    public override void EnterState() 
    { 
        foreach(var behaviour in behaviours)
            behaviour.Enter();
        
    }
    public override void ExitState() 
    {
        foreach (var behaviour in behaviours)
            behaviour.Exit();
    } 
    public override void UpdateState()
    {
        foreach (var behaviour in behaviours)
            behaviour.Update();
    }
    public override void LateUpdateState()
    {
        foreach (var behaviour in behaviours)
            behaviour.LateUpdate();
    }
    public override void FixedUpdateState()
    {
        foreach (var behaviour in behaviours)
            behaviour.FixedUpdate();
    } 
}
 