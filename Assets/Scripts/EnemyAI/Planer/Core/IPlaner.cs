using EnemyAI.Actions;
using EnemyAI.Context;

namespace EnemyAI.Planer
{
    public interface IPlaner<T> where T : IContext
    {
        void SubscribeActions(T context);
        void UnsubscribeActions(T context);
        void UpdateContext(T context);
        void RegisterAction(IAction<T> action);
    } 
}
