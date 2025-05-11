
using EnemyAi;
using State.Machine;

namespace  State.Enemy
{
    public abstract class EnemyStateBase : IStateGame
    {
        public EnemyStateBase(IStateMachine stateMachine,IBehaviourHandler behaviour)
        {
            this.stateMachine = stateMachine;
            this.behaviour = behaviour; 
        }
        private protected readonly IStateMachine stateMachine;
        private protected readonly IBehaviourHandler behaviour; 
        public abstract void EnterState();
        public abstract void ExitState();
        public abstract void UpdateState();

        public abstract void LateUpdateState();
        public abstract void FixedUpdateState();
    }
     
}


