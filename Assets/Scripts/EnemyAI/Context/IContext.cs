using System;

namespace EntityAI.Context
{
    public interface EntityAI
    {
        event Action OnExecuteMoveAction;
          
        bool isHasInteract { get;}
        bool isFocus { get; }

        bool isIdle { get; }
        bool isRundomMove { get; }
        bool isRandomRotate { get; }
        bool isHasRaycastHitTarget { get;}
        bool isHasTarget { get;}
        bool isInAttackRange { get; }
       
        bool isFollowTarget { get; } 
        bool isLoockTarget { get; } 
        bool isAttackTarget { get; }
        void UpdateContext();
        void SetStateTarget();
        void ResetStateTarget();
    }
}

