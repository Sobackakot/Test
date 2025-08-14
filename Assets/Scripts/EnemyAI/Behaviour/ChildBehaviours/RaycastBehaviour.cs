using EntityAI.Behaviour;
using UnityEngine;


namespace EntityAI
{
    public class RaycastBehaviour : BehaviourBase
    {
        public RaycastBehaviour(IEntity entity) : base(entity)
        {
        }
        public bool isHit { get; private set; }
        public override bool RaycastForward(Vector3 targetPos)
        {
            Vector3 direction = GetDirectionTarget(targetPos); 
            var ray = GetRayForward(direction);
            isHit = Physics.Raycast(ray, out RaycastHit hit, entity.config.maxDistanceRaycast, entity.config.targetLayerMask);
            Debug.DrawRay(entity.components.raycastPoint.position, direction * entity.config.maxDistanceRaycast, isHit ? Color.red : Color.white);
            Debug.Log("isHit " + isHit);
            return isHit;
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