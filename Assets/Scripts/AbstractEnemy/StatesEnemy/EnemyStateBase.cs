
using EnemyAI;
using EnemyAI.Behaviour;
using State.Machine;
using System.Collections.Generic;

namespace  State.Enemys
{
    public abstract class EnemyStateBase : IStateGame
    {
        public EnemyStateBase(Enemy enemy,IStateMachine stateMachine, IBehaviourHandler behaviourHandler)
        {
            this.enemy = enemy;
            this.stateMachine = stateMachine;
            this.behaviourHandler = behaviourHandler; 
        }
        private protected List<IBehaviourBase> behaviours = new();
        private protected readonly Enemy enemy;
        private protected readonly IStateMachine stateMachine;
        private protected readonly IBehaviourHandler behaviourHandler; 
        public abstract void EnterState();
        public abstract void ExitState();
        public abstract void UpdateState();

        public abstract void LateUpdateState();
        public abstract void FixedUpdateState();
    }
     
}


