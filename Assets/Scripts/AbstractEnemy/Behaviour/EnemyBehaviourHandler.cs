using EnemyAI;

namespace EnemyAI.Behaviour
{
    public class EnemyBehaviourHandler
    { 
        public IEnemyIdle idle { get; private set; }
        public IEnemyMove move { get; private set; }
        public IEnemyRotate rotate { get; private set; }
        public IEnemyRandomMove ranMove { get; private set; }
        public IEnemyRandomRotate ranRot { get; private set; }
        public IEnemyFollowTarget followTar { get; private set; }
        public IEnemyLoockTarget loockTar { get; private set; }
        public IEnemyAttackTarget attack { get; private set; }

        public void InitIdleBehaviour(IEnemyIdle idle) => this.idle = idle;
        public void InitMoveBehaviour(IEnemyMove move) => this.move = move;
        public void InitRotateBehaviour(IEnemyRotate rotate) => this.rotate = rotate;
        public void InitRandomMove(IEnemyRandomMove ranMove) => this.ranMove = ranMove;
        public void InitRandomRotate(IEnemyRandomRotate ranRot) => this.ranRot = ranRot;
        public void InitFollowTarget(IEnemyFollowTarget followTar) => this.followTar = followTar;
        public void InitLoockTarget(IEnemyLoockTarget loockTar) => this.loockTar = loockTar;
        public void InitAttackTarget(IEnemyAttackTarget attackTarget) => attack = attackTarget;
    }
}

