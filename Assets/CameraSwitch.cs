using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private GameObject playerCam;
    [SerializeField] private GameObject challengeCam;

    private void OnTriggerEnter(Collider other)
    {
        challengeCam.SetActive(false);
        playerCam.SetActive(true);
    }
}
