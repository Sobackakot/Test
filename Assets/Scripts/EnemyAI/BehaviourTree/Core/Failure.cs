using BehaviourFree.Node;
using EntityAI;

namespace BehaviourFree
{
    public class Failure : NodeBase
    {
        public Failure(IEntity entity)
        {
            this.entity = entity;
        }
        private IEntity entity;
        public override Status Evaluate()
        {
            return Status.Failure;
        }
    }
}