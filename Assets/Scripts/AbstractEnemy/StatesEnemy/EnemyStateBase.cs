
using EnemyAi;

namespace State
{
    public abstract class EnemyStateBase : IStateGame
    {
        public EnemyStateBase(Enemy enemy)
        {
            this.enemy = enemy;
        }
        protected readonly Enemy enemy;
        public abstract void EnterState();
        public abstract void ExitState();
        public abstract void UpdateState();
    }
     
}


