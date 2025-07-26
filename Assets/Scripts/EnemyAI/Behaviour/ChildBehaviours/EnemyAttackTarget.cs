using UnityEngine;
using EnemyAI.Behaviour;
using Entity;

namespace EnemyAI
{ 
    public class EnemyAttackTarget : BehaviourBase
    {
        public EnemyAttackTarget(IEntity enemy) : base(enemy)
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
            AttackTarget();
        }
        public override void LateUpdate()
        {

        }
        public override void FixedUpdate()
        {
             
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
