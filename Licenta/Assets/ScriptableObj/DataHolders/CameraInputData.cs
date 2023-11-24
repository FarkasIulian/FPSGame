using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName ="InputData", menuName = "InputData/CameraInputDataHolder")]
public class CameraInputData : ScriptableObject
{
    [Header("Camera")]
    public float xSensitivity = 30f;
    public float ySensitivity = 30f;
}




