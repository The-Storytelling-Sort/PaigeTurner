using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BookTransporter : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject destination;
    [SerializeField] private GameObject[] meshes;
    [SerializeField] private VisualEffect poof;
    [SerializeField] private float teleportDelay;
    public GameObject prevLine;
    public GameObject currentLine;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Teleport());
            if (poof)
            {
                poof.Play();   
            }
            
            foreach (GameObject mesh in meshes)
            {
                mesh.SetActive(false);
            }
        }
        
    }

    public IEnumerator Teleport()
    {
        yield return new WaitForSeconds(teleportDelay);
        player.transform.position = destination.transform.position;

        if (prevLine)
        {
            prevLine.SetActive(false);
            currentLine.SetActive(true);
        }

        foreach (GameObject mesh in meshes)
        {
            mesh.SetActive(true);
        }
    }
}
