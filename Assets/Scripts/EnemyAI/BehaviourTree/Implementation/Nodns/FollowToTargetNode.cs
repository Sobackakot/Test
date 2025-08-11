using EntityAI;
using EntityAI.Repository;
using static UnityEngine.GraphicsBuffer;
using UnityEngine;

namespace BehaviourFree.Node
{
    public class FollowToTargetNode : NodeBase
    { 
        private readonly IEntity entity; 

        public FollowToTargetNode(IEntity entity)
        {
            this.entity = entity;
        }

        public override Status Evaluate()
        {
            if (entity.context.isHasTarget && !entity.context.isInAttackRange)
            {
                entity.components.agent.SetDestination(entity.repository.currentTarget.targetTr.position);
                StoppedDestination();
                return Status.Running;
            }

            return Status.Failure;
        }
        public void StoppedDestination()
        {
            float distance = Vector3.Distance(entity.components.trEntity.position, entity.repository.currentTarget.targetTr.position);
            if (distance <= 2)
            {
                entity.components.agent.velocity = Vector3.zero;
                ResetFocus();
            }
        }
     
        public void ResetFocus()
        {
            entity.context.OnResetInteract();
            entity.repository.SetCurrentTarget(null); 
        }
    }
}