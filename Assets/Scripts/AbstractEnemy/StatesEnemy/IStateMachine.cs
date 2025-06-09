using State.Enemys;
using System;

namespace State.Machine 
{
    public interface IStateMachine: IFSM
    { 
        void AddTransition(StateType stateType, Func<StateType> transition);
        void RegisterState(StateType stateType, IStateGame state);
        void SetState(StateType stateType);
        void UpdateState();
        void LateUpdateState();
        void FixedUpdateState(); 
    } 
}

