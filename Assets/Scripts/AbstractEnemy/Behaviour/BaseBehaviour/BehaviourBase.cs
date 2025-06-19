using EnemyAI; 
using UnityEngine;

namespace EnemyAI.Behaviour
{
    public abstract class BehaviourBase :
        IBehaviourIdle,
        IBehaviourMove,
        IBehaviourRotate,
        IBehaviourRandomMove,
        IBehaviourRandomRotate,
        IBehaviourFollowTarget,
        IBehaviourLoockTarget,
        IBehaviourAttackTarget
    {
        public BehaviourBase(Enemy enemy)
        {
            this.enemy = enemy; 
        } 
        public Enemy enemy { get; set; }
        public virtual void IdleState()
        {
        }
        public virtual void Moving(Vector3 targetMove)
        {
        }
        public virtual void Rotating(Quaternion targetRotation)
        {
        }
        public virtual void RandomMove()
        {
        }
        public virtual void RandomRotate()
        {
        }
        public virtual void FollowTarget()
        {
        }
        public virtual void LoockTarget()
        {

        }
        public virtual void AttackTarget()
        {
        }

        public virtual void Enter()
        { 
        }

        public virtual void Exit()
        { 
        }

        public virtual void Update()
        { 
        }
        public virtual void LateUpdate()
        {
        }
        public virtual void FixedUpdate()
        {
        }
    }
}