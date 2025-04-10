namespace EnemyAi
{
    public class EnemyRandomMove : EnemyMove 
    {
        public EnemyRandomMove(Enemy enemy) : base(enemy) { }
        public override void RandomMove()
        {
            if (!enemy.isIdle && enemy.isRundomMove && !enemy.isAttackTarget)
            {
                Moving(enemy.tr.forward);
            }
        }
    }
}