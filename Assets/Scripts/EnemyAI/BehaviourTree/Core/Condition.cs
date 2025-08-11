namespace BehaviourFree.Node
{
    public abstract class Condition : NodeBase
    {
        private readonly NodeBase _child;

        protected Condition(NodeBase child)
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