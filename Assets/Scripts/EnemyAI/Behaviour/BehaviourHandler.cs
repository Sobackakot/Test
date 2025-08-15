using System;
using System.Collections.Generic;

namespace EntityAI.Behaviour
{
    public class BehaviourHandler : IBehaviourHandler
    {
        private Dictionary<Type, IBehaviourBase> _behaviours = new();
        public Dictionary<Type, IBehaviourBase> behaviours => _behaviours;
        
        T IBehaviourHandler.GetBehaviour<T>()
        {
            return behaviours.TryGetValue(typeof(T), out var value) ? value as T : null;
        }
          
        void IBehaviourHandler.RegisterBehaviour<T>(T behaviour)
        {
            if (behaviour == null || behaviours.ContainsKey(typeof(T))) return;
            behaviours.Add(typeof(T),behaviour);
        }
    }
}