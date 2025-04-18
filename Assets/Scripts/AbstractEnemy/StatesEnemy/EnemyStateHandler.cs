using EnemyAi; 
using UnityEngine;

namespace EnemyAi.State
{
    public class EnemyStateHandler
    {
        public IStateGame currentState;
        public void SetState(IStateGame newState)
        {
            if (currentState != newState)
            {
                currentState?.ExitState();
                currentState = newState;
                currentState?.EnterState();
            }
        }
        public void UpdateState()
        {
            currentState?.UpdateState();
        }
    }
}

