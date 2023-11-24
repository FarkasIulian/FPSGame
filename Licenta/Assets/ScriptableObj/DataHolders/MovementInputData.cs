using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName ="InputData", menuName = "InputData/MovementInputDataHolder")]
public class MovementInputData : ScriptableObject
{
    [HideInInspector]public bool isGrounded;
    [HideInInspector]public bool isSprinting = false;
    [HideInInspector]public float gravity  = -9.8f;
    [HideInInspector]public bool isCrouching = false;
    [HideInInspector]public bool lerpCrouching = false;
    [HideInInspector]public float crouchTimer;

    [Header("Speeds")]
    public float crouchingSpeed = 5f;
    public float walkingSpeed = 8f;
    public float sprintingSpeed = 15f; 


    [Header("Jumping")]
    public float jumpHeight = 3f; // this represents the ammount that will be added to the y position of the player

    

}
