
using EnemyAi;

namespace State
{
    public abstract class EnemyStateBase : IStateGame
    {
        public EnemyStateBase(IEnemyIdle idle,
        IEnemyMove move,
        IEnemyRotate rotate,
        IEnemyRandoMove randomMove,
        IEnemyRandomRotate randomRotate,
        IEnemyFollowTarget followTarget,
        IEnemyLoockTarget loockTarget,
        IEnemyAttackTarget attackTarget )
        {
            this.idle = idle;
            this.move = move;
            this.rotate = rotate;
            this.randomMove = randomMove;
            this.randomRotate = randomRotate;
            this.followTarget = followTarget;
            this.loockTarget = loockTarget;
            this.attackTarget = attackTarget; 
        }

        public readonly IEnemyIdle idle;
        public readonly IEnemyMove move;
        public readonly IEnemyRotate rotate;
        public readonly IEnemyRandoMove randomMove;
        public readonly IEnemyRandomRotate randomRotate;
        public readonly IEnemyFollowTarget followTarget;
        public readonly IEnemyLoockTarget loockTarget;
        public readonly IEnemyAttackTarget attackTarget;
        public abstract void EnterState();
        public abstract void ExitState();
        public abstract void UpdateState();
    }
     
}


