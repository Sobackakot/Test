
namespace BehaviourFree.Node
{
    public abstract class NodeBase

    {
        public enum Status
        {
            Failure = 0,
            Running,
            Success,
        }

        public abstract Status Evaluate();
    }
}

