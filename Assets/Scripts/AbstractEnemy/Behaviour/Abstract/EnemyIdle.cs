using UnityEngine;
using EnemyAi.Behaviour;
namespace EnemyAi
{
    public class EnemyIdle : EnemyBehaviourBase 
    {
        public EnemyIdle(Enemy enemy) : base(enemy) { }
        public override void IdleState()
        {
            if (enemy.isIdle && !enemy.isRundomMove && !enemy.isFollowTarget)
            {
                Debug.Log("Idle Behaviour ");
            }
        } 
    }
}