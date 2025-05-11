namespace EnemyAi
{
    public class EnemyRandomMove : EnemyRandomRotate
    {
        public EnemyRandomMove(Enemy enemy) : base(enemy) { }
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
            RandomRotate();
        }
        public override void RandomMove()
        {
            if (!enemy.isIdle && enemy.isRundomMove && !enemy.isAttackTarget)
            {
                Moving(enemy.tr.forward);
            }
        }
    }
}