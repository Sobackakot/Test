using EntityAI;
using EntityAI.Behaviour;
using System.Collections.Generic;
using UnityEngine;

namespace State.Enemys
{
    public class AttackEnemyState : EnemyStateBase
    {
        public AttackEnemyState(IEntity enemy) : base(enemy)
        {
            var type = StateType.Attack;
            var stateMachine = enemy.stateMachine;
            var behaviourHandler = enemy.behaviourHandler;

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
