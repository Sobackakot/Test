using EntityAI.Behaviour;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;


namespace EntityAI
{
    public class RaycastBehaviour : BehaviourBase
    { 
        public RaycastBehaviour(IEntity entity) : base(entity)
        { 
        }
        LayerMask layer;
        public override bool RaycastForward(Vector3 targetPos)
        {
            Vector3 origin = entity.components.raycastPoint.position;

            Vector3 direction = GetDirectionTarget(targetPos);
            float distance = entity.config.maxDistanceRaycast;
            var ray = GetRayForward(direction);

            bool isHit = Physics.Raycast(ray, out RaycastHit hit, distance, entity.config.raycastLayers); 
            if (hit.collider !=null)
                isHit = ((1 << hit.collider.gameObject.layer) &entity.config.targetLayer.value) != 0;   
            Debug.DrawRay(origin, direction * distance, isHit ? Color.red : Color.white);

            return isHit;
        }
        private Vector3 GetDirectionTarget(Vector3 targetPos)
        {
            return (targetPos - entity.components.raycastPoint.position).normalized;
        }
        private Ray GetRayForward(Vector3 directionTarget)
        {
            return new Ray(entity.components.raycastPoint.position, directionTarget);
        }
    }
}