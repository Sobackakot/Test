using UnityEngine;
using EnemyAi.Behaviour;

namespace EnemyAi
{
    public class EnemyFollowTarget : EnemyLoockTarget
    {
        public EnemyFollowTarget(Enemy enemy) : base(enemy){ }
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
            LoockTarget();
        }
        public override void FollowTarget()
        {
            if (!enemy.isIdle && enemy.isFollowTarget && !enemy.isAttackTarget)
            {
                Vector3 targetMove = (enemy.target.position - enemy.tr.position).normalized;
                Moving(targetMove);
            }
        }
    }
}