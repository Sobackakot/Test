using System;

namespace EnemyAI.Context
{
    public interface IContext
    {
        event Action OnExecuteMoveAction;
        void UpdateContext();
    }
}

