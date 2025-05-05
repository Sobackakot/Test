using UnityEngine;
using EnemyAi.Behaviour;

namespace EnemyAi
{ 
    public class EnemyAttackTarget : EnemyLoockTarget
    {
        public EnemyAttackTarget(Enemy enemy) : base(enemy) { }
        public override void Enter()
        {
        }

        public override void Exit()
        {
        }

        public override void Update()
        {
            AttackTarget();
            LoockTarget();
        }
        public override void AttackTarget()
        {
            if (enemy.isAttackTarget)
            {
                Debug.Log("Attacke Behaviour");
            }
        }
    } 
}
