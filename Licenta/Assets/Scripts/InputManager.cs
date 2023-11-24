using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Inputs playerInputs;
    private Inputs.OnFootActions onFootActions;
    private Movement movement;
    private PlayerCamera playerCamera;
    
    void Awake()
    {
        //get movement script
        movement = GetComponent<Movement>();

        playerCamera = GetComponent<PlayerCamera>();
        
        // instantiate the input manager actions
        playerInputs = new Inputs();
        onFootActions = playerInputs.OnFoot;
        
        
        //subscribe to the jump action
        onFootActions.Jump.performed += (ctx) => movement.Jump();

        //subscribe to the sprint action
        onFootActions.Sprint.performed += (ctx) => movement.Sprint();

        onFootActions.Crouch.performed += (ctx) => movement.Crouch();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }


    private void OnEnable()
    {
        onFootActions.Enable();
    }

    private void OnDisable()
    {
        onFootActions.Disable();
    }

    void FixedUpdate()
    {
        movement.Move(onFootActions.Movement.ReadValue<Vector2>());
        playerCamera.Look(onFootActions.Camera.ReadValue<Vector2>());

    }

}
