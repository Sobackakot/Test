public class MoveAction : IAction<CharacterContext>
{
    public bool CanExecute(CharacterContext context)
    {
        context.Update();
        return context.isMove;    
    }

    public void Execute(CharacterContext context)
    { 
        context.character.ShowText("moveAction"); 
    }
}
