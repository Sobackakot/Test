using EntityAI.Actions;
using EntityAI.Context;
using System.Collections.Generic;


namespace EntityAI.Planer
{
    public class Planer<T> : IPlaner<T> where T : Context.EntityAI
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

