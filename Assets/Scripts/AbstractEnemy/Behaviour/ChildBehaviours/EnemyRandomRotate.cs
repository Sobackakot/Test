using EnemyAI.Behaviour;
using UnityEngine; 
namespace EnemyAI
{
    public class EnemyRandomRotate : EnemyRotate
    {
        public EnemyRandomRotate(Enemy enemy) : base(enemy)
        {
        }
        private float time;
         

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }

        public override void Update()
        {

        }
        public override void LateUpdate()
        {

        }
        public override void FixedUpdate()
        { 
            RandomRotate();
        }
        public override void RandomRotate()
        {
            if (enemy.context.isRandomRotate)
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