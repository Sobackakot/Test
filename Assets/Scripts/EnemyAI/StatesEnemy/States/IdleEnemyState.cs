using EntityAI;
using System.Collections.Generic;
using EntityAI.Behaviour;
using UnityEngine;



namespace State.Enemys
{
    public class IdleEnemyState : EnemyStateBase
    {
        public IdleEnemyState(IEntity entity) : base(entity)
        {
            var type = StateType.Idle;

            var fsm = entity.stateMachine;
            var behHandler = entity.behaviourHandler;

            fsm.AddTransition(type, () => !entity.context.isIdle ? StateType.Move : type);
            fsm.AddTransition(type, () => entity.context.isRundomMove ? StateType.Move : type);
            fsm.AddTransition(type, () => entity.context.isFollowTarget ? StateType.Follow : type);

            behaviours = new List<IBehaviourBase>()
        {
            behHandler.GetBehaviour<IBehaviourIdle>(),
            behHandler.GetBehaviour<IBehaviourLoockTarget>(),
            behHandler.GetBehaviour<IBehaviourRandomRotate>()
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