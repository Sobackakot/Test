using EntityAI.Context;

namespace BehaviourFree.Node
{
    public class HasTargetCondition : ConditionNode
    {
        private readonly IContext _context;

        public HasTargetCondition(IContext context, NodeBase child) : base(child)
        {
            _context = context;
        }

        protected override bool CanEvaluate()
        { 
            return _context.isHasTarget;
        }
    } 
}
