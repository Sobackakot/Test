using EnemyAi;
using State.Enemys;
using State.Machine; 
public class IdleEnemyState : EnemyStateBase
{
    public IdleEnemyState(IStateMachine stateMachine, IBehaviourHandler behaviour, Enemy enemy) 
        : base(stateMachine, behaviour, enemy)
    {
        var type = StateType.Idle;
        stateMachine.AddTransition(type, () => !enemy.isIdle ? StateType.Move : type);
        stateMachine.AddTransition(type, () => enemy.isRundomMove ? StateType.Move : type);
        stateMachine.AddTransition(type, () => enemy.isFollowTarget ? StateType.Follow : type);
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
