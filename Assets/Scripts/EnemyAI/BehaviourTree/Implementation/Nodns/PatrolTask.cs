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
            if (entity.config.patrolPoints == null || entity.config.patrolPoints.Length == 0)
            { 
                return Status.Failure;
            }  
            if (entity.components.agent.remainingDistance <= entity.components.agent.stoppingDistance)
            { 
                _currentPointIndex = (_currentPointIndex + 1) % entity.config.patrolPoints.Length; 
                entity.components.agent.SetDestination(entity.config.patrolPoints[_currentPointIndex]);
            }
            return Status.Running;
        }
    }
}