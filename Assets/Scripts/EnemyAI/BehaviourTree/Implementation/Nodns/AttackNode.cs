using EntityAI;
using UnityEngine;

namespace BehaviourFree.Node
{
    public class AttackNode : NodeBase
    {
        private readonly IEntity entity;
        public AttackNode(IEntity entity)
        {
            this.entity = entity;
        }

        public override Status Evaluate()
        {
            if (entity.context.isHasTarget && entity.context.isInAttackRange)
            { 
                if (UpdateInteract()) return Status.Success;
                Debug.Log("Attack");
                return Status.Running;
            }
            entity.context.OnResetInteract();
            return Status.Failure;
        }
        private bool UpdateInteract()
        {
            if (entity.context.isFocus && !entity.context.isHasInteract)
            {
                float distance = Vector3.Distance(entity.components.trTarget.position, entity.components.trEntity.position);
                if (distance <= entity.config.minDistanceInteract)
                {
                    Debug.Log("Interact");
                    entity.context.OnResetInteract();
                    return true;
                }
                else return false;

            }
            else return false;
        }
    }
}