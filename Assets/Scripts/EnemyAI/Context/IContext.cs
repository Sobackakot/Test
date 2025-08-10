using EntityAI.Repository;
using System;
using System.Collections.Generic;

namespace EntityAI.Context
{
    public interface IContext
    {
        event Action OnExecuteMoveAction;
          
        bool isHasInteract { get;}
        bool isFocus { get; }

        bool isIdle { get; }
        bool isRundomMove { get; }
        bool isRandomRotate { get; }
        bool isHasRaycastHitTarget { get;}
        bool isFollowTarget { get; } 
        bool isLoockTarget { get; } 
        bool isAttackTarget { get; }
        void UpdateContext();
    }
}

