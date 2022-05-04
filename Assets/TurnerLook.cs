using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnerLook : MonoBehaviour
{
    [SerializeField] private GameObject auri;
    private Transform offset;
    // private void Start()
    // {
    //     offset.transform
    // }
    
    void Update()
    {
        transform.LookAt(auri.transform);
    }
}
