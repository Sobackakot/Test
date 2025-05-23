using UnityEngine;

namespace EnemyAi
{
    public class EnemyRotate : EnemyMove
    {
        public EnemyRotate(Enemy enemy) : base(enemy) { }
 
        public override void Rotating(Quaternion targetRotation)
        {
            Quaternion newRot = Quaternion.Slerp(enemy.tr.rotation, targetRotation, enemy.angleRotate * Time.fixedDeltaTime);
            enemy.rb.MoveRotation(newRot);
        }
    }
}