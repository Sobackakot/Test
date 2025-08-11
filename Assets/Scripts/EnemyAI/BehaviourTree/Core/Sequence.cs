namespace BehaviourFree.Node
{
    public class Sequence : CompositeNode
    {
        public Sequence(params NodeBase[] nodes) : base(nodes) { }

        public override Status Evaluate()
        {
            foreach (var child in children)
            {
                switch (child.Evaluate())
                {
                    case Status.Failure:
                        return Status.Failure;
                    case Status.Success:
                        continue;
                    case Status.Running:
                        return Status.Running;
                }
            }
            return Status.Success;
        }
    }
}