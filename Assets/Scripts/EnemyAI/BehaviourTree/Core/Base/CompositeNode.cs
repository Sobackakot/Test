
using System.Collections.Generic;

namespace BehaviourFree.Node
{
    public abstract class CompositeNode : NodeBase
    {
        protected List<NodeBase> children = new List<NodeBase>();

        public CompositeNode(params NodeBase[] nodes)
        {
            children.AddRange(nodes);
        }
    }

}
