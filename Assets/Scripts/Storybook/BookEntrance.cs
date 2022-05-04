using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BookEntrance : MonoBehaviour
{
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject storybookCamera;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerCamera.SetActive(false);
            storybookCamera.SetActive(true);
        }
    }
}

