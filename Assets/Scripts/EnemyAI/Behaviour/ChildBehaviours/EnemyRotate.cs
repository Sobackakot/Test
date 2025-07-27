using EntityAI.Behaviour;
using EntityAI;
using UnityEngine;

namespace EntityAI
{
    public class EnemyRotate : BehaviourBase
    {
        public EnemyRotate(IEntity enemy) : base(enemy)
        { 
        }

        public override void Rotating(Quaternion targetRotation)
        {
            Quaternion newRot = Quaternion.Slerp(enemy.components.tr.rotation, targetRotation, enemy.config.angleRotate * Time.fixedDeltaTime);
            enemy.components.rb.MoveRotation(newRot);
        }
    }
}