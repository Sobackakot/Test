using UnityEngine;

namespace EnemyAi
{
    public class EnemyRandomRotate : EnemyRotate 
    {
        public EnemyRandomRotate(Enemy enemy) : base(enemy)
        {
        }

        public override void RandomRotate()
        {
            if (enemy.isRundomRotate)
            {
                float currentY = enemy.tr.eulerAngles.y;
                float turnAmount = Random.Range(enemy.minAngle, enemy.maxAngle);
                if (Random.value > 0.5f) turnAmount *= -1;
                float newY = currentY + turnAmount;
                Quaternion targetRotation = Quaternion.Euler(0, newY, 0);
                Rotating(targetRotation);
            }
        }
    }
}