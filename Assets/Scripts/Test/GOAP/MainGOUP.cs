using UnityEngine;
using Test.Context;
using Test.Actions;
using Test.Plane;
public class MainGOUP : MonoBehaviour
{
    private Character character;
    private Planer<CharacterContext> planer;
    private CharacterContext context;
    private void Start()
    {
        character = FindObjectOfType<Character>();
        context = new(character);
        planer = new();
        planer.AddAction(new MoveAction());
        planer.AddAction(new AttckAction());
    }
    private void Update()
    {
       
        planer.Run(context);
        
    }
}
