using EntityAI.Context;

namespace EntityAI.Actions
{
    public interface IAction<in T> where T : Context.EntityAI
    {
        IEntity entity { get;}
        void Subscribe(T context);
        void Unsubscribe(T context);
        void Execute(T context);
    }
}

