using System;
using System.Collections.Generic;

namespace EntityAI.Behaviour
{
    public interface IBehaviourHandler 
    {
        Dictionary<Type, IBehaviourBase> behaviours { get; }
        void RegisterBehaviour<T>(T behaviour) 
            where T : class, IBehaviourBase;
        T GetBehaviour<T>() 
            where T : class, IBehaviourBase;
    }
}

