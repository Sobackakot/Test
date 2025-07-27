using UnityEngine;
using EntityAI.Behaviour;
using Entity;

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
            if (!enemy.context.isIdle && enemy.context.isFollowTarget && !enemy.context.isAttackTarget)
            {
                Vector3 targetMove = (enemy.target.position - enemy.tr.position).normalized;
                Moving(targetMove);
            }
        }
    }
}