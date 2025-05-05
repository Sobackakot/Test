using UnityEngine; 
namespace EnemyAi
{
    public class EnemyRandomRotate : EnemyLoockTarget
    {
        private float time;
        public EnemyRandomRotate(Enemy enemy) : base(enemy) { }
 
        public override void RandomRotate()
        {
            if (enemy.isRundomRotate )
            {
                float turnAmount = 0;
                float currentY = enemy.tr.eulerAngles.y; 
                if (time < Time.time)
                {
                    time = Time.time + Random.Range(0.5f, 1.5f);
                    turnAmount = Random.Range(enemy.minAngle, enemy.maxAngle);
                    if (Random.value > 0.5f) turnAmount *= -1;
                }  
                float newY = currentY + turnAmount;
                Quaternion targetRotation = Quaternion.Euler(0, newY, 0);
                Rotating(targetRotation);
            }
        }
    }
}