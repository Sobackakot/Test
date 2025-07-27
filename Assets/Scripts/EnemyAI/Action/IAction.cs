using EntityAI.Context;
using State.Machine;

namespace EntityAI.Actions
{
    public interface IAction<in T> where T : IContext
    {
        IFSM fsm { get; set; }
        void Subscribe(T context);
        void Unsubscribe(T context);
        void Execute(T context);
    }
}

