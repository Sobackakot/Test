using EnemyAI.Actions;
using EnemyAI.Context;
using State.Machine;

public class EnemyMoveAction : IAction<IContext>
{
    public EnemyMoveAction(IFSM fsm)
    {
        this.fsm = fsm;
    }

    public IFSM fsm { get ; set; }

    public void Subscribe(IContext context)
    {
        context.OnExecuteMoveAction += fsm.TryTransition;
    }

    public void Unsubscribe(IContext context)
    {
        context.OnExecuteMoveAction -= fsm.TryTransition;
    }
    public void Execute(IContext context)
    {
        context.UpdateContext();
    }
}
