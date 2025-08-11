using EntityAI.Context;

namespace BehaviourFree.Node
{
    public class AttackRangeCondition : Condition
    {
        private readonly IContext _context;

        public AttackRangeCondition(IContext context, NodeBase child) : base(child)
        {
            _context = context;
        }

        protected override bool CanEvaluate()
        {
            return _context.isInAttackRange;
        }
    }

}
