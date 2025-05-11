using State.Machine;
using System;
using System.Collections.Generic;

namespace State.Enemy
{
    public class EnemyStateHandler : IStateMachine
    {
        public IStateGame currentState;
        public StateType currentStateType;

        private readonly Dictionary<StateType, IStateGame> states = new();
        private readonly Dictionary<StateType, List<Func<StateType>>> transitions = new();

        public void SetState(StateType stateType)
        {
            if (!states.ContainsKey(stateType)) return;
            currentState?.ExitState();
            currentState = states[stateType];
            currentStateType = stateType;
            currentState?.EnterState();
        }
        public void AddTransition(StateType stateType, Func<StateType> transition)
        {
            if (!transitions.ContainsKey(stateType))
            {
                transitions[stateType] = new List<Func<StateType>>();
            }
            transitions[stateType].Add(transition);
        }
        public void RegisterState(StateType stateType, IStateGame state)
        {
            if(!states.ContainsKey(stateType))
                states[stateType] = state;
        }
       

        public void UpdateState()
        {
            if(transitions.TryGetValue(currentStateType, out List<Func<StateType>> rules))
            {
                foreach(var rule in rules)
                {
                    StateType newStateType = rule.Invoke();
                    if (!EqualityComparer<StateType>.Default.Equals(newStateType, currentStateType))
                    {
                        SetState(newStateType);
                        break;
                    }
                }
            }
            currentState?.UpdateState();
        }
        public void LateUpdateState()
        {
            currentState?.LateUpdateState();
        } 
        public void FixedUpdateState()
        {
            currentState?.FixedUpdateState();
        } 
    }
    public enum StateType
    {
        Idle,
        Move,
        Follow,
        Attack
    }
}

