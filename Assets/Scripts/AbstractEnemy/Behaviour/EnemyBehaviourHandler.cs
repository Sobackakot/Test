using EnemyAi;

namespace EnemyAi.Behaviour
{
    public class EnemyBehaviourHandler
    {
        public EnemyBehaviourHandler(Enemy enemy)
        {
            Idle = new(enemy);
            Attack = new(enemy);
            Rotate = new(enemy);
            Move = new(enemy);
            RanRotate = new(enemy);
            RanMove = new(enemy);
            Follow = new(enemy);
            Loock = new(enemy);
        }
        public EnemyIdle Idle { get; private set; }
        public EnemyAttackTarget Attack { get; private set; }
        public EnemyRotate Rotate { get; private set; }
        public EnemyMove Move { get; private set; }
        public EnemyRandomRotate RanRotate { get; private set; }
        public EnemyRandomMove RanMove { get; private set; }
        public EnemyFollowTarget Follow { get; private set; }
        public EnemyLoockTarget Loock { get; private set; }
    }
}

