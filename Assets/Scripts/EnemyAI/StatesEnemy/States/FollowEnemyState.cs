using EntityAI;
using EntityAI.Behaviour;
using System.Collections.Generic;


namespace State.Enemys
{
    public class FollowEnemyState : EnemyStateBase
    {
        public FollowEnemyState(IEntity enemy) : base(enemy)
        {
            var type = StateType.Follow;
            var stateMachine = enemy.stateMachine;
            var behaviourHandler = enemy.behaviourHandler;

            stateMachine.AddTransition(type, () => !enemy.context.isFollowTarget ? StateType.Idle : type);
            behaviours = new List<IBehaviourBase>()
        {
            behaviourHandler.GetBehaviour<IBehaviourFollowTarget>(),
            behaviourHandler.GetBehaviour<IBehaviourLoockTarget>()
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