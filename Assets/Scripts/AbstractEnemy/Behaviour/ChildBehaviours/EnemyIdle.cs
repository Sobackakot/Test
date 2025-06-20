using EnemyAI.Behaviour;
using UnityEngine; 

namespace EnemyAI
{
    public class EnemyIdle : BehaviourBase
    {
        public EnemyIdle(Enemy enemy) : base(enemy)
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
            IdleState();
           
        }
         public override void LateUpdate()
        {

        }
        public override void FixedUpdate()
        { 
        }
        public override void IdleState()
        {
            if (enemy.context.isIdle && !enemy.context.isRundomMove && !enemy.context.isFollowTarget)
            { 
            }
        } 
    }
}