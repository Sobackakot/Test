using EntityAI;
using EntityAI.Behaviour;
using EntityAI.Repository;
using UnityEngine;

namespace BehaviourFree.Node
{
    public class FindTargetNode : NodeBase
    { 
        private readonly TargetSearchBehaviour search;
        private readonly IEntity entity;
        public FindTargetNode(IEntity entity, TargetSearchBehaviour search)
        {  
            this.entity = entity;
            this.search = search;
        }
        float _time;
        public override Status Evaluate()
        { 
            Searching();
            if (entity.repTarTrans.currentTarget == null)
            {  
                return Status.Failure;
            } 
            else
            { 
                entity.context.SetStateTarget();  
                return Status.Success;
            }
        }
        private void Searching()
        {
            if(_time <= Time.time)
            {
                entity.repTarTrans.nearTargets.Clear();
                entity.repTarTrans.detectedTargets.Clear();
                entity.repTarTrans.rayHitTargets.Clear();
                entity.repTarTrans.SetCurrentTarget(null);
                entity.context.ResetStateTarget();

                var position = entity.components.trEntity.position;
                var direction = entity.components.trEntity.forward;
                search.SearchNearbyTargets(position, entity.config.visionRadius);
                search.SearchDetectedTargets(position, direction, entity.config.viewAngle);
                search.SearchRaycastHitTargets();
                search.SearchBestTarget(position);  
                _time = Time.time + 0.5f;
            }
  
        }
       
    }
}
