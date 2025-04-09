using UnityEngine;
using EnemyAi.Behaviour;

namespace EnemyAi
{
    public class EnemyFollowTarget : EnemyMove 
    {
        public EnemyFollowTarget(Enemy enemy) : base(enemy)
        {
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