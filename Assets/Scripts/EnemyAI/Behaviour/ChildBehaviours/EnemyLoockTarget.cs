using UnityEngine;
namespace EntityAI
{
    public class EnemyLoockTarget : EnemyRotate
    {
        public EnemyLoockTarget(IEntity enemy) : base(enemy)
        {
        }

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
            LoockTarget();
        }
        public override void LoockTarget()
        {
            if (enemy.context.isLoockTarget)
            {
                Vector3 loockTarget = (enemy.components.target.position - enemy.components.tr.position).normalized;
                Quaternion targetRotation = Quaternion.LookRotation(new Vector3(loockTarget.x, 0, loockTarget.z));
                Rotating(targetRotation);
            }
        }
    }
}