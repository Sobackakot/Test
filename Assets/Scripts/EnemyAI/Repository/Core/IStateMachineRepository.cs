using EntityAI;
using State.Machine;
using System.Collections.Generic;

namespace EntityAI.Repository
{
    public interface IStateMachineRepository 
    {
        Dictionary<IEntity, IStateMachine> stateMachines { get; }
        void RegisterStateMachine(IEntity enemy,IStateMachine fsm);
        void UnregisterStateMachine(IEntity enemy);
    }
}