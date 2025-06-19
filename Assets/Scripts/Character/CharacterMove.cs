
using System.Collections; 
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
        if(input!=null)
            input.onMoving += Input_OnMoving;
    }
    private void OnDisable()
    {
        if (input != null)
            input.onMoving -= Input_OnMoving;
    }
    private void FixedUpdate()
    {
        Moving(inputAxis);
        Sprint();
    }
    private void Input_OnMoving(Vector2 input)
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        inputAxis = new Vector3(x, 0, y);
    }
    private void Moving(Vector3  input)
    {
        rbChar.MovePosition(rbChar.position + input * speedMove * Time.fixedDeltaTime);
    }
    bool isSprinting = true; 
    public void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) & isSprinting)
        {
            StartCoroutine(SprintWaitTime());
            speedMove = 15;
        }
        else
        { 
            StopCoroutine(SprintWaitTime());
            StartCoroutine(SprintWaitTime2());
            speedMove = 5;
        }
    }
    public IEnumerator SprintWaitTime()
    {
        yield return new WaitForSeconds(7);
        isSprinting = false; 
    } 
    public IEnumerator SprintWaitTime2()
    {
        yield return new WaitForSeconds(7);
        isSprinting = true; 
    }

    private float currentHP = 100;
    public bool isReadyForBattle { get; private set; }
    public void TakeDamage(float damage)
    {
        if (currentHP <= 0)
        {
            Debug.Log("Game Over");
            //turnOff MoveController
            //playAnim dead
            //waitTime 4 seconds for stopGame
            Time.timeScale = 0;
        }
        else currentHP -= damage;
    }
}
