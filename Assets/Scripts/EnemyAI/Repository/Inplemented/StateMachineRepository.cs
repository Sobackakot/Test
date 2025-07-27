using EntityAI;
using EntityAI.React;
using State.Machine;
using System.Collections.Generic;


namespace EntityAI.Repository
{
    public class StateMachineRepository : ObserverContextBase<StateMachineActionType>, IStateMachineRepository  
    {
        public StateMachineRepository(IActionSubject<StateMachineActionType, IObserverContext<StateMachineActionType>> subject) : base(subject)
        {
            Register(StateMachineActionType.StateMachineReg, (IEntity enemy, IStateMachine fsm) => RegisterStateMachine(enemy, fsm));
            Register(StateMachineActionType.StateMachineUnreg, (IEntity enemy) => UnregisterStateMachine(enemy));
            SubscribeAll();
        }
        Dictionary<IEntity, IStateMachine> _stateMachines = new();
         
        public Dictionary<IEntity, IStateMachine> stateMachines => _stateMachines;

        public void RegisterStateMachine(IEntity enemy, IStateMachine fsm)
        {
            if (!stateMachines.ContainsKey(enemy))
                _stateMachines.Add(enemy, fsm);
        }

        public void UnregisterStateMachine(IEntity enemy)
        {
            if(stateMachines.ContainsKey(enemy))
                _stateMachines.Remove(enemy);
        }
    }
}