
using EntityAI;

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


