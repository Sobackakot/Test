using EntityAI;
using EntityAI.Actions;
using EntityAI.Context;

public class EnemyMoveAction : IAction<IContext>
{
    public EnemyMoveAction(IEntity entity)
    {
        this.entity = entity;
    }

    public IEntity entity { get ; private set; }

    public void Subscribe(IContext context)
    {
        context.OnExecuteMoveAction += entity.stateMachine.TryTransition;
    }

    public void Unsubscribe(IContext context)
    {
        context.OnExecuteMoveAction -= entity.stateMachine.TryTransition;
    }
    public void Execute(IContext context)
    {
        context.UpdateContext();
    }
}
