using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookRotation : MonoBehaviour
{
    [SerializeField] private GameObject turner;

    private void Awake()
    {
        
    }

    void Update()
    {
        this.transform.rotation = Quaternion.AngleAxis(turner.transform.rotation.y,Vector3.right);
    }
}
