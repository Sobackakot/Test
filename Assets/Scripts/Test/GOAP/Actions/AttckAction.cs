using Test.Context;
using Test.Actions;
public class AttckAction : IAction<CharacterContext>
{
    public bool CanExecute(CharacterContext context)
    {
        context.Update();
        return context.character.isAttack;    
    }

    public void Execute(CharacterContext context)
    { 
        context.character.ShowText("attackContext"); 
    }
}
