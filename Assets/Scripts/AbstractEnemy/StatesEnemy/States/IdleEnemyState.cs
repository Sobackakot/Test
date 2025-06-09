using EnemyAI;
using State.Enemys;
using State.Machine; 
public class IdleEnemyState : EnemyStateBase
{
    public IdleEnemyState(IStateMachine stateMachine, IBehaviourHandler behaviour, Enemy enemy) 
        : base(stateMachine, behaviour, enemy)
    {
        var type = StateType.Idle;
        stateMachine.AddTransition(type, () => !enemy.context.isIdle ? StateType.Move : type);
        stateMachine.AddTransition(type, () => enemy.context.isRundomMove ? StateType.Move : type);
        stateMachine.AddTransition(type, () => enemy.context.isFollowTarget ? StateType.Follow : type);
    }

    public override void EnterState() 
    { 
        behaviour.Enter();
       
    }
    public override void ExitState()
    {
        behaviour.Exit();
    }
    public override void UpdateState()
    {
        behaviour.Update();
    }
    public override void LateUpdateState()
    {
        behaviour.LateUpdate();
    }

    public override void FixedUpdateState()
    {
        behaviour.FixedUpdate();
    }
}
