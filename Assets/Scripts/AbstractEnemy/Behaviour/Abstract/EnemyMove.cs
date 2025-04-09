using UnityEngine;

namespace EnemyAi
{
    public class EnemyMove : EnemyBehaviourBase 
    {
        public EnemyMove(Enemy enemy) : base(enemy)
        {
        }

        public override void Moving(Vector3 targetMove)
        {
            Rigidbody rb = enemy.rb;
            rb.MovePosition(rb.position + targetMove.normalized * enemy.speedMove * Time.fixedDeltaTime);
        }
    }
}