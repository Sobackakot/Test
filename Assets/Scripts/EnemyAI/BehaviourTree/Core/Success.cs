using BehaviourFree.Node;
using EntityAI;

namespace BehaviourFree
{
    public class Success : NodeBase
    { 
        public Success(IEntity entity)
        {
            this.entity = entity;
        }
        private IEntity entity;
        public override Status Evaluate()
        {
            return Status.Success;
        }
    }
}