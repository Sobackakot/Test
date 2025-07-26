using UnityEngine;
using EnemyAI.Behaviour;
using Entity;
namespace EnemyAI
{
    public class EnemyMove : BehaviourBase 
    {
        public EnemyMove(IEntity enemy) : base(enemy)
        { 
        }

        public override void Moving(Vector3 targetMove)
        {
            Rigidbody rb = enemy.rb;
            rb.MovePosition(rb.position + targetMove.normalized * enemy.speedMove * Time.fixedDeltaTime);
        }
    }
}