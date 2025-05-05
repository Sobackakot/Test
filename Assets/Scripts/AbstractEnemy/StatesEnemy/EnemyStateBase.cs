
using EnemyAi;

namespace EnemyAi.State
{
    public abstract class EnemyStateBase : IStateGame
    {
        public EnemyStateBase(IBehaviourHandler behaviour)
        {
            this.behaviour = behaviour; 
        }

        public readonly IBehaviourHandler behaviour; 
        public abstract void EnterState();
        public abstract void ExitState();
        public abstract void UpdateState();
    }
     
}


