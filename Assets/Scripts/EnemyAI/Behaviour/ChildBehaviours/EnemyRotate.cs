using EnemyAI.Behaviour;
using Entity;
using UnityEngine;

namespace EnemyAI
{
    public class EnemyRotate : BehaviourBase
    {
        public EnemyRotate(IEntity enemy) : base(enemy)
        { 
        }

        public override void Rotating(Quaternion targetRotation)
        {
            Quaternion newRot = Quaternion.Slerp(enemy.tr.rotation, targetRotation, enemy.angleRotate * Time.fixedDeltaTime);
            enemy.rb.MoveRotation(newRot);
        }
    }
}