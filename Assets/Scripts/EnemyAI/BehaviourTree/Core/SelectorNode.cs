namespace BehaviourFree.Node
{
    public class SelectorNode : CompositeNode
    {
        public SelectorNode(params NodeBase[] nodes) : base(nodes) { }

        public override Status Evaluate()
        {
            foreach (var child in children)
            {
                switch (child.Evaluate())
                {
                    case Status.Failure:
                        continue;
                    case Status.Success:
                        return Status.Success;
                    case Status.Running:
                        return Status.Running;
                }
            }
            return Status.Failure;
        }
    }
}