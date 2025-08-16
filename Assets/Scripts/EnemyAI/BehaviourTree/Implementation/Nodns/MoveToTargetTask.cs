using EntityAI;
using UnityEngine;

namespace BehaviourFree.Node
{
    public class MoveToTargetTask : NodeBase
    { 
        private readonly IEntity entity; 

        public MoveToTargetTask(IEntity entity)
        {
            this.entity = entity;
        }

        public override Status Evaluate()
        { 
            if (entity.repository.currentTarget == null)
            { 
                return Status.Failure;  
            }
              
            if (entity.components.agent.remainingDistance <= entity.components.agent.stoppingDistance)
            { 
                StoppedDestination(); 
                return Status.Success; 
            }
            else
            { 
                entity.components.agent.SetDestination(entity.repository.currentTarget.targetTr.position); 
                return Status.Running;  
            } 
        }
        public void StoppedDestination()
        {
            float distance = Vector3.Distance(entity.components.trEntity.position, entity.repository.currentTarget.targetTr.position);
            if (distance <= 2)
            {
                entity.components.agent.velocity = Vector3.zero; 
            }
        }
      
    }
}