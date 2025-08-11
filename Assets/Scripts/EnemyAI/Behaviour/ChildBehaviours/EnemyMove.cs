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
            Rigidbody rb = entity.components.rbEntity;
            rb.MovePosition(rb.position + targetMove.normalized * entity.config.speedMove * Time.fixedDeltaTime);
        }
    }
}