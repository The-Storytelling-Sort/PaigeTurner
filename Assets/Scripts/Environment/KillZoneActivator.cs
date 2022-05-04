using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZoneActivator : MonoBehaviour
{
    [SerializeField] private GameObject killZone;

    [SerializeField] private bool activator;
    [SerializeField] private bool deactivator;

    public void OnTriggerEnter(Collider other)
    {
        if(activator == true)
        {
            killZone.SetActive(true);
        }
        if (deactivator == true)
        {
            killZone.SetActive(false);
        }
    }
}

