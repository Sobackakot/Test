using EntityAI;

namespace BehaviourFree.Node
{
    public class HasTargetCondition : ConditionNode
    {
        private readonly IEntity entity;

        public HasTargetCondition(IEntity entity, NodeBase child) : base(child)
        {
            this.entity = entity;
        }

        protected override bool CanEvaluate()
        { 
            return entity.context.isHasTarget;
        }
    } 
}
