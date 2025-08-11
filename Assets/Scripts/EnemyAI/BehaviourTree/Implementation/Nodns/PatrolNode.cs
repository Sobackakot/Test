using EntityAI;

namespace BehaviourFree.Node
{
    public class PatrolNode : NodeBase
    {
        private readonly IEntity entity;
       
        private int _currentPointIndex = 0;

        public PatrolNode(IEntity entity)
        {
            this.entity = entity;
        }

        public override Status Evaluate()
        { 
            if (entity.context.isHasTarget) return Status.Failure; // Ќачинаем патрулировать, только если нет цели

            if (!entity.components.agent.pathPending && entity.components.agent.remainingDistance < 0.5f)
            {
                _currentPointIndex = (_currentPointIndex + 1) %  entity.config.patrolPoints.Length;
                entity.components.agent.SetDestination(entity.config.patrolPoints[_currentPointIndex]);
            }

            return Status.Running;
        }
    }
}