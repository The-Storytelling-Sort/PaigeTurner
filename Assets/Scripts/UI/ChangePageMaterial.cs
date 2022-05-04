using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePageMaterial : MonoBehaviour
{ 
    public Material[] material;
    Renderer rend;

    private CameraChecker camerachecker;

    public float RenderSwapDelay = 0.75f;


    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        camerachecker = GameObject.FindObjectOfType<CameraChecker>();
    }

    public void Transistion2to3()
    {
        rend.sharedMaterial = material[1];
    }

    public void Transistion4to5()
    {
        rend.sharedMaterial = material[3];
    }

    void Update()
    {
       if (camerachecker.flipped2to3)
        {
            Invoke("Transistion2to3", RenderSwapDelay);
        }

        if (camerachecker.flipped4to5)
        {
            Invoke("Transistion4to5", RenderSwapDelay);
        }
    }
}

