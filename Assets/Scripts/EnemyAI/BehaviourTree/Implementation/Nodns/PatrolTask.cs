using EntityAI;
using UnityEngine;

namespace BehaviourFree.Node
{
    public class PatrolTask : NodeBase
    {
        private readonly IEntity entity;
       
        private int _currentPointIndex = 0;

        public PatrolTask(IEntity entity)
        {
            this.entity = entity;
        }

        public override Status Evaluate()
        { 
            if (entity.context.isHasTarget) return Status.Failure; // Ќачинаем патрулировать, только если нет цели

            if (entity.components.agent.remainingDistance <= entity.components.agent.stoppingDistance)
            {
                Debug.Log("patrule");
                _currentPointIndex = (_currentPointIndex + 1) %  entity.config.patrolPoints.Length;
                entity.components.agent.SetDestination(entity.config.patrolPoints[_currentPointIndex]);
                return Status.Success;
            }

            return Status.Running;
        }
    }
}