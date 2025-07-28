
using EntityAI;
using EntityAI.Behaviour;
using State.Machine;
using System.Collections.Generic;

namespace  State.Enemys
{
    public abstract class EnemyStateBase : IStateGame
    {
        public EnemyStateBase(IEntity entity)
        {
            this.enemy = entity;
        }
        private protected List<IBehaviourBase> behaviours = new();
        private protected readonly IEntity enemy;
        public abstract void EnterState();
        public abstract void ExitState();
        public abstract void UpdateState();

        public abstract void LateUpdateState();
        public abstract void FixedUpdateState();
    }
     
}


