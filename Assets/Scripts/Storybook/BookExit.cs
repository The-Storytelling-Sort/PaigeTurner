using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookExit : MonoBehaviour
{
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject storybookCamera;
    [SerializeField] private GameObject finalLine;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            storybookCamera.SetActive(false);
            playerCamera.SetActive(true);
            finalLine.SetActive(false);
        }
    }
}
