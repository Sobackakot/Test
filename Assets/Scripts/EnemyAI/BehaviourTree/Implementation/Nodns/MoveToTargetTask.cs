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
            if (entity.components.agent.remainingDistance <= entity.components.agent.stoppingDistance)
            { 
                StoppedDestination();
                Debug.Log("Finish Follow");
                return Status.Success; 
            }
            entity.components.agent.SetDestination(entity.repTarTrans.currentTarget.targetTr.position);
            return Status.Running;
        }
        public void StoppedDestination()
        {
            float distance = Vector3.Distance(entity.components.trEntity.position, entity.repTarTrans.currentTarget.targetTr.position);
            if (distance <= 2)
            {
                entity.components.agent.velocity = Vector3.zero; 
            }
        }
      
    }
}