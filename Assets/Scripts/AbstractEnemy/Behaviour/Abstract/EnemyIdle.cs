using UnityEngine; 

namespace EnemyAi
{
    public class EnemyIdle : EnemyRandomRotate
    {
        public EnemyIdle(Enemy enemy) : base(enemy) { }
        public override void Enter()
        {
        }

        public override void Exit()
        {
        }

        public override void Update()
        {
            IdleState();
            RandomRotate();
            LoockTarget();
        }
        public override void IdleState()
        {
            if (enemy.isIdle && !enemy.isRundomMove && !enemy.isFollowTarget)
            {
                Debug.Log("Idle Behaviour ");
            }
        } 
    }
}