using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSky : MonoBehaviour
{
    [SerializeField] float RotateSpeed = 1.25f;


    void Update()
    {
        RenderSettings.skybox.SetFloat ("_Rotation", Time.time * RotateSpeed);
    }
}
