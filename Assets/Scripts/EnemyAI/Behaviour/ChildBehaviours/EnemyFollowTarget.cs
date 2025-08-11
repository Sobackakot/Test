using UnityEngine;

namespace EntityAI
{
    public class EnemyFollowTarget : EnemyMove
    {
        public EnemyFollowTarget(IEntity enemy) : base(enemy)
        {
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }

        public override void Update()
        {
           
        }
        public override void LateUpdate()
        {

        }
        public override void FixedUpdate()
        {
            FollowTarget(); 
        }
        public override void FollowTarget()
        {
            if (!entity.context.isIdle && entity.context.isFollowTarget && !entity.context.isAttackTarget)
            {
                Vector3 targetMove = (entity.components.trTarget.position - entity.components.trEntity.position).normalized;
                Moving(targetMove);
            }
        }
    }
}