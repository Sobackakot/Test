using UnityEngine;
using EnemyAI.Behaviour;

namespace EnemyAI
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
        }
        public override void LateUpdate()
        {

        }
        public override void FixedUpdate()
        {
            
            LoockTarget();
        }
     
        public override void AttackTarget()
        {
            if (enemy.context.isAttackTarget)
            {
                Debug.Log("Attacke Behaviour");
            }
        }
    } 
}
