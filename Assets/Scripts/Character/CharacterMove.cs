
using Unity.VisualScripting;
using UnityEngine; 

public class CharacterMove : MonoBehaviour
{
    private InputActions input;
    private Rigidbody rbChar;
    public Vector3 inputAxis { get; private set; }
    public float speedMove = 4f;
    private void Awake()
    { 
        rbChar = GetComponent<Rigidbody>();
        input = FindObjectOfType<InputActions>();
    } 
    private void OnEnable()
    {
        input.onMoving += Input_OnMoving;
    }
    private void OnDisable()
    {
        input.onMoving -= Input_OnMoving;
    }
    private void FixedUpdate()
    {
        Moving(inputAxis);
    }
    private void Input_OnMoving(Vector2 input)
    {
        inputAxis = new Vector3(input.x, 0, input.y);
    }
    private void Moving(Vector3  input)
    {
        rbChar.MovePosition(rbChar.position + input * speedMove * Time.fixedDeltaTime);
    }
}
