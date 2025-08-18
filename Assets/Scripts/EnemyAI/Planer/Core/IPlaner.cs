using EntityAI.Actions;
using EntityAI.Context;

namespace EntityAI.Planer
{
    public interface IPlaner<T> where T : Context.EntityAI
    {
        void SubscribeActions(T context);
        void UnsubscribeActions(T context);
        void UpdateContext(T context);
        void RegisterAction(IAction<T> action);
    } 
}
