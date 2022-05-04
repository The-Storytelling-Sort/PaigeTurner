using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramerateLimit : MonoBehaviour
{
    public int frameRateLimit = 30;

    void Start()
    {
        // Limits framerate
        Application.targetFrameRate = frameRateLimit;
    }
}
