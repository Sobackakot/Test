using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyAI.Action
{
    public interface IAction<T> where T : class
    {
        void Subscribe();
        void Unsubscribe();
    }
}

