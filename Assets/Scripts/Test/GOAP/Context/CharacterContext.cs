using Test.Context;
using Test.Actions;
public class CharacterContext : IContext
{
    public CharacterContext(Character character)
    {
        this.character = character;
    }
    public Character character;
    public bool isActive;
    public bool isMove;
    public IContext Copy()
    { 
        return new CharacterContext(character)
        {
            isActive = isActive,
            isMove = isMove
        };
    }

    public void Update()
    {
        isActive = character.isAttack; 
        isMove = character.isMove; 
    }
}
