namespace EntityAI
{
    public class EnemyRandomMove : EnemyMove
    {
        public EnemyRandomMove(IEntity enemy) : base(enemy)
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
            RandomMove(); 
        }
        public override void RandomMove()
        {
            if (!enemy.context.isIdle && enemy.context.isRundomMove && !enemy.context.isAttackTarget)
            {
                Moving(enemy.components.tr.forward);
            }
        }
    }
}