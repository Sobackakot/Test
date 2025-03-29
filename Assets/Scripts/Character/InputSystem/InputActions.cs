
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class InputActions : MonoBehaviour
{ 
    private ActionsMap actionsMap; 
    public event Action<Vector2> onMoving;

    private PlayerInput playerInput;
    private InputAction moveAction;

    private void Awake()
    { 
        actionsMap = new ActionsMap();
        playerInput = GetComponent<PlayerInput>();
    }
    private void Start()
    {
        SetInputActions();
    }
    private void OnEnable()
    {
        actionsMap.Enable();
        actionsMap.CharacterActions.Moving.performed += ctx => Moving(ctx);
        actionsMap.CharacterActions.Moving.canceled += ctx => Moving(ctx);
    }
    private void OnDisable()
    {
        actionsMap.CharacterActions.Moving.performed -= ctx => Moving(ctx);
        actionsMap.CharacterActions.Moving.canceled -= ctx => Moving(ctx);
        actionsMap.Dispose();
    }
    private void Update()
    {
        UpdateInputAction();
    }
    private void Moving(CallbackContext context)
    {
        if (context.performed)
        {
            onMoving?.Invoke(moveAction.ReadValue<Vector2>());
           
        } 
        else if (context.canceled)
        {
            onMoving?.Invoke(Vector2.zero);
        }
           
    }
    private void SetInputActions()
    {
        moveAction = playerInput.actions["Moving"];
    }
    private void UpdateInputAction()
    {
        onMoving?.Invoke(moveAction.ReadValue<Vector2>());
    }
    
}
