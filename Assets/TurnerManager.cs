using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnerManager : MonoBehaviour
{
    [SerializeField] private GameObject prevTurner;
    [SerializeField] private GameObject nextTurner;
    [SerializeField] private float waitTime;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(SwitchTurner());
    }

    public IEnumerator SwitchTurner()
    {
        yield return new WaitForSeconds(waitTime);
        prevTurner.SetActive(false);
        nextTurner.SetActive(true);
    }
    
}
