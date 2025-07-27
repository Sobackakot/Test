using EntityAI;
using Entity;
using UnityEngine;

namespace EntityAI.Behaviour
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
        public BehaviourBase(IEntity enemy)
        {
            this.enemy = enemy; 
        } 
        public IEntity enemy { get; set; }
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