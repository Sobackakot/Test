using EnemyAI.Actions;
using EnemyAI.Context;
using System.Collections.Generic;


namespace EnemyAI.Plane
{
    public class Planer<T> where T : IContext
    {
        public readonly List<IAction<T>> actions = new();
        public void RegisterAction(IAction<T> action) => actions.Add(action);

        public void SubscribeActions(T context)
        {
            foreach (var action in actions)
            {
                action.Subscribe(context);
            }
        }
        public void UnsubscribeActions(T context)
        {
            foreach(var action in actions)
            {
                action.Unsubscribe(context);
            }
        }
        public void UpdateContext(T context)
        {
            foreach (var action in actions)
            {
                action.Execute(context);
            }
        }
    } 
}

