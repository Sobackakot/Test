
using EntityAI;
using EntityAI.Behaviour;
using System.Collections.Generic;


namespace State.Enemys
{
    public class MoveEnemyState : EnemyStateBase
    {
        public MoveEnemyState(IEntity enemy) : base(enemy)
        {
            var type = StateType.Move;

            var stateMachine = enemy.stateMachine;
            var behaviourHandler = enemy.behaviourHandler;

            stateMachine.AddTransition(type, () => !enemy.context.isRundomMove ? StateType.Idle : type);
            stateMachine.AddTransition(type, () => enemy.context.isIdle ? StateType.Idle : type);
            stateMachine.AddTransition(type, () => enemy.context.isFollowTarget ? StateType.Follow : type);

            behaviours = new List<IBehaviourBase>()
        {
            behaviourHandler.GetBehaviour<IBehaviourRandomMove>(),
            behaviourHandler.GetBehaviour<IBehaviourRandomRotate>()
        };
        }

        public override void EnterState()
        {
            foreach (var behaviour in behaviours)
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
}