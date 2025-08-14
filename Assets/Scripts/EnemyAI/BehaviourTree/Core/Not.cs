using BehaviourFree.Node;

namespace BehaviourFree
{
    public class Not : NodeBase
    {
        private readonly NodeBase _child;

        public Not(NodeBase child)
        {
            _child = child;
        }

        public override Status Evaluate()
        { 
            var status = _child.Evaluate();
             
            if (status == Status.Success)
            {
                return Status.Failure;
            }
            if (status == Status.Failure)
            {
                return Status.Success;
            } 
            return status;
        }
    }
}