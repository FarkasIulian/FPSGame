using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    
    private float xRotation = 0f;
    public Camera mainCamera;
    public CameraInputData data;

    public void Look(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        //xRotation actually represents looking up and down
        xRotation -= (mouseY * Time.deltaTime) * data.ySensitivity;

        // lock the camera to only be able to look up and down 90 degress so you cant rotate fully with camera
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // rotate the camera based on the xRotation and we dont need to rotate on y and z axis
        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //rotate player left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * data.xSensitivity);
    
    }
}
