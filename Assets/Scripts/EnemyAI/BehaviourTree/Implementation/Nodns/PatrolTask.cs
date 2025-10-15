using EntityAI;

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
            if (entity.config.patrolPoints == null || entity.config.patrolPoints.Count == 0)
            { 
                return Status.Failure;
            }  
            if (entity.components.agent.remainingDistance <= entity.components.agent.stoppingDistance)
            { 
                _currentPointIndex = (_currentPointIndex + 1) % entity.config.patrolPoints.Count; 
                entity.components.agent.SetDestination(entity.config.patrolPoints[_currentPointIndex].position);
                return Status.Success;
            } 
            return Status.Running;
        }
    }
}