using EntityAI.Behaviour;
using UnityEngine;


namespace EntityAI
{
    public class RaycastBehaviour : BehaviourBase
    {
        public RaycastBehaviour(IEntity entity) : base(entity)
        {
        }
        public override void Enter()
        { 
        }

        public override void Exit()
        {
        }
        public override void Update()
        {
        }
        public override void LateUpdate()
        {
        }
        public override void FixedUpdate()
        {
        }
        

        public override bool RaycastForward(Vector3 targetPos)
        {
            entity.config.SetDirection(GetDirectionTarget(targetPos));
            var ray = GetRayForward(entity.config.directionTarget);
            if (Physics.Raycast(ray, out RaycastHit hit, entity.config.maxDistanceRaycast, entity.config.targetLayerMask))
                return true;
            else return false;
        }
        private Vector3 GetDirectionTarget(Vector3 targetPos)
        {
            return targetPos - entity.components.raycastPoint.position;
        }
        private Ray GetRayForward(Vector3 directionTarget)
        {
            return new Ray(entity.components.raycastPoint.position, directionTarget);
        }
    }
}