using UnityEngine;
using EnemyAi.Behaviour;
namespace EnemyAi
{
    public class EnemyLoockTarget : EnemyRotate 
    {
        public EnemyLoockTarget(Enemy enemy) : base(enemy) { }
        
        public override void LoockTarget()
        {
            if (enemy.isLoockTarget)
            {
                Vector3 loockTarget = (enemy.target.position - enemy.tr.position).normalized;
                Quaternion targetRotation = Quaternion.LookRotation(new Vector3(loockTarget.x, 0, loockTarget.z));
                Rotating(targetRotation);
            }
        }
    }
}