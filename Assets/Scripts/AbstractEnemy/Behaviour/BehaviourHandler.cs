using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace EnemyAI.Behaviour
{
    public class BehaviourHandler : IBehaviourHandler
    {
        private readonly Dictionary<Type, IBehaviourBase> behaviours = new();
        
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