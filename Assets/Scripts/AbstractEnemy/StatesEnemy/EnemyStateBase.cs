
using EnemyAI;
using State.Machine;

namespace  State.Enemys
{
    public abstract class EnemyStateBase : IStateGame
    {
        public EnemyStateBase(IStateMachine stateMachine,IBehaviourHandler behaviour, Enemy enemy)
        {
            this.stateMachine = stateMachine;
            this.behaviour = behaviour;
            this.enemy = enemy;
        }
        private protected readonly Enemy enemy;
        private protected readonly IStateMachine stateMachine;
        private protected readonly IBehaviourHandler behaviour; 
        public abstract void EnterState();
        public abstract void ExitState();
        public abstract void UpdateState();

        public abstract void LateUpdateState();
        public abstract void FixedUpdateState();
    }
     
}


