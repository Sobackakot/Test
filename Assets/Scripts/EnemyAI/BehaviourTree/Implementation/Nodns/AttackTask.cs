using EntityAI;
using UnityEngine;

namespace BehaviourFree.Node
{
    public class AttackTask : NodeBase
    {
        private readonly IEntity entity;
        public AttackTask(IEntity entity)
        {
            this.entity = entity;
        }

        public override Status Evaluate()
        {
            if (UpdateInteract()) return Status.Success;
            return Status.Failure; 
        }
        private bool UpdateInteract()
        {
            float distance = Vector3.Distance(entity.components.trTarget.position, entity.components.trEntity.position);
            if (distance <= entity.config.minDistanceInteract)
            {
                entity.context.ResetStateTarget();
                return true;
            }
            else return false;
        }
    }
}