using System.Collections;
using System.Collections.Generic;
using UnityEngine; 


namespace EnemyAI.Behaviour
{
    public interface IBehaviourHandler
    { 
        void RegisterBehaviour<T>(T behaviour) 
            where T : class, IBehaviourBase;
        T GetBehaviour<T>() 
            where T : class, IBehaviourBase;
    }
}

