
using EnemyAI;

namespace State
{ 
    public interface IStateGame
    { 
        void EnterState();
        void ExitState();
        void UpdateState();
        void LateUpdateState();
        void FixedUpdateState();
    }
}


