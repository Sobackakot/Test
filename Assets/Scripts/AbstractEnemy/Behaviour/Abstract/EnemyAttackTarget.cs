using UnityEngine;
using EnemyAi.Behaviour;

namespace EnemyAi
{ 
    public class EnemyAttackTarget : EnemyBehaviourBase 
    {
        public EnemyAttackTarget(Enemy enemy) : base(enemy) { } 
        public override void AttackTarget()
        {
            if (enemy.isAttackTarget)
            {
                Debug.Log("Attacke Behaviour");
            }
        }
    } 
}
