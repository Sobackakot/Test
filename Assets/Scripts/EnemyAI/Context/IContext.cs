using System;

namespace EntityAI.Context
{
    public interface IContext
    {
        event Action OnExecuteMoveAction; 
        bool isIdle { get; }
        bool isRundomMove { get; }
        bool isRandomRotate { get; }
        
        bool isFollowTarget { get; } 
        bool isLoockTarget { get; } 
        bool isAttackTarget { get; }
        void UpdateContext();
    }
}

