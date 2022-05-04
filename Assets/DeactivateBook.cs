using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateBook : MonoBehaviour
{
    [SerializeField] private GameObject deactivate;
    [SerializeField] private GameObject activate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            deactivate.SetActive(false);
            activate.SetActive(true);   
        }
    }
}
