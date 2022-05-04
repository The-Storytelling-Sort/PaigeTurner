using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TODisabler : MonoBehaviour
{
    [SerializeField] private GameObject toDisable;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            toDisable.SetActive(false);
        }
    }

}
