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
        IBehaviourAttackTarget,
        IBehaviourSearchTarget,
        IBehaviourInteract,
        IBehaviourRaycast
    {
        public BehaviourBase(IEntity entity)
        {
            this.entity = entity; 
        } 
        public IEntity entity { get; set; }
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
        public virtual bool RaycastForward(Vector3 targetPos)
        {
            return false;
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