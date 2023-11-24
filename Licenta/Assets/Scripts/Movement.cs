using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController characterController;
    private Vector2 playerVelocity;
    private float speed;
    public MovementInputData data;
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        speed = data.walkingSpeed;
    }

    void Update()
    {
        data.isGrounded = characterController.isGrounded;
        if (data.lerpCrouching)
        {
            data.crouchTimer += Time.deltaTime;
            float p = data.crouchTimer;
            p *= p;
            if (data.isCrouching)
            {
                characterController.height = Mathf.Lerp(characterController.height, 1, p);
                speed = data.crouchingSpeed;
            }
            else
            {
                characterController.height = Mathf.Lerp(characterController.height, 2, p);
                speed = data.isSprinting ? data.sprintingSpeed : data.walkingSpeed;
            }

            if(p > 1)
            {
                data.lerpCrouching = false;
                data.crouchTimer = 0;
            }
        }


    }

    // Update is called once per frame
    public void Move(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        characterController.Move(transform.TransformDirection(moveDirection) * Time.deltaTime * speed);

        // add gravity to the player
        playerVelocity.y += data.gravity * Time.deltaTime;
        // stop applying gravity if player is grounded so that we can jump later
        if(data.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        characterController.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(playerVelocity.y);
    }

    public void Jump()
    {
        if (data.isGrounded && !data.isCrouching)
        {
            playerVelocity.y = Mathf.Sqrt(data.jumpHeight * -2.0f * data.gravity);
            //Debug.Log(playerVelocity.y);
        }
        //Debug.Log(transform.position.y);

    }
   
    public void Sprint()
    {
        data.isSprinting = !data.isSprinting;
        if (data.isSprinting && !data.isCrouching && data.isGrounded)
        {
            speed = data.sprintingSpeed;
        }
        else if (data.isCrouching)
            speed = data.crouchingSpeed;
        else speed = data.walkingSpeed;
    }

    public void Crouch()
    {
        if (data.isGrounded)
        {
            data.isCrouching = !data.isCrouching;
            data.crouchTimer = 0;
            data.lerpCrouching = true;
        }
    }
}
