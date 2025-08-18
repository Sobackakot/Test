using EntityAI;
using UnityEngine;

namespace BehaviourFree.Node
{
    public class AttackRangeCondition : ConditionNode
    {
        private readonly IEntity entity;

        public AttackRangeCondition(IEntity entity, NodeBase child) : base(child)
        {
            this.entity = entity;
        }

        protected override bool CanEvaluate()
        {
            return IsMinDistance(entity.config.minDistanceAttackTarget);
        }
        private bool IsMinDistance(float minDistance)
        {
            return Vector3.Distance(entity.components.trEntity.position, entity.components.trTarget.position) <= minDistance;
        }
    }

}
