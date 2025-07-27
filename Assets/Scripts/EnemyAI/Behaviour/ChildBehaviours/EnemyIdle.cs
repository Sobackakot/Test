using EntityAI.Behaviour;
using Entity;
using UnityEngine; 

namespace EntityAI
{
    public class EnemyIdle : BehaviourBase
    {
        public EnemyIdle(IEntity enemy) : base(enemy)
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