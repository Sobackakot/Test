using UnityEngine;

namespace EnemyAi
{
    public class EnemyLoockTarget : EnemyRotate 
    {
        public EnemyLoockTarget(Enemy enemy) : base(enemy)
        {
        }

        public override void LoockTarget()
        {
            if (enemy.isLoockTarget)
            {
                Vector3 targetMove = (enemy.target.position - enemy.tr.position).normalized;
                Quaternion targetRotation = Quaternion.LookRotation(new Vector3(targetMove.x, 0, targetMove.z));
                Rotating(targetRotation);
            }
        }
    }
}