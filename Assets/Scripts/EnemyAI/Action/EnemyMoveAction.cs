using EntityAI;
using EntityAI.Actions;
using EntityAI.Context;

public class EnemyMoveAction : IAction<EntityAI.Context.EntityAI>
{
    public EnemyMoveAction(IEntity entity)
    {
        this.entity = entity;
    }

    public IEntity entity { get ; private set; }

    public void Subscribe(EntityAI.Context.EntityAI context)
    {
        context.OnExecuteMoveAction += entity.stateMachine.TryTransition;
    }

    public void Unsubscribe(EntityAI.Context.EntityAI context)
    {
        context.OnExecuteMoveAction -= entity.stateMachine.TryTransition;
    }
    public void Execute(EntityAI.Context.EntityAI context)
    {
        context.UpdateContext();
    }
}
