using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    [Header("Rotation Speed on Axis")]
    public float X;
    public float Y;
    public float Z;


    void Update()
    {
        if(Time.timeScale != 0)
            transform.Rotate (X, Y, Z);
    }
}
