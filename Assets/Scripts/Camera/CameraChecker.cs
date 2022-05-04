using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChecker : MonoBehaviour
{
    public bool is2D;
    public bool is3D;
    public bool isGliding;
    public bool flipped2to3;
    public bool flipped4to5;
    public bool flipped6to7;
    public bool flipped8to9;

    void Start()
    {
        is2D = false;
        is3D = false;
        flipped2to3 = false;
        flipped4to5 = false;
        flipped6to7 = false;
        flipped8to9 = false;
        isGliding = false;
    }
}
