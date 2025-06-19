using EnemyAI.Behaviour;
using UnityEngine;

namespace EnemyAI
{
    public class EnemyRotate : BehaviourBase
    {
        public EnemyRotate(Enemy enemy) : base(enemy)
        { 
        }

        public override void Rotating(Quaternion targetRotation)
        {
            Quaternion newRot = Quaternion.Slerp(enemy.tr.rotation, targetRotation, enemy.angleRotate * Time.fixedDeltaTime);
            enemy.rb.MoveRotation(newRot);
        }
    }
}