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
    }
    private void Update()
    {
        planer.AddAction(new MoveAction());
        planer.AddAction(new AttckAction());
        planer.Run(context);
        
    }
}
