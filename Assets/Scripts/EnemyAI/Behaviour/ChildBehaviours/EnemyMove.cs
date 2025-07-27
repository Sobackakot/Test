using EntityAI.Behaviour;
using UnityEngine;
namespace EntityAI
{
    public class EnemyMove : BehaviourBase 
    {
        public EnemyMove(IEntity enemy) : base(enemy)
        { 
        }

        public override void Moving(Vector3 targetMove)
        {
            Rigidbody rb = enemy.components.rb;
            rb.MovePosition(rb.position + targetMove.normalized * enemy.config.speedMove * Time.fixedDeltaTime);
        }
    }
}