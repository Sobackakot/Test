namespace BehaviourFree.Node
{
    public abstract class ConditionNode : NodeBase
    {
        private readonly NodeBase _child;

        protected ConditionNode(NodeBase child)
        {
            _child = child;
        }
       
        public override Status Evaluate() =>
            CanEvaluate()
                ? _child.Evaluate()
                : Status.Failure;
        protected abstract bool CanEvaluate();
    }
}