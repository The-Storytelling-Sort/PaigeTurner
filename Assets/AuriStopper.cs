using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class AuriStopper : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject speaker;
    [SerializeField] private float waitTimer;
    [SerializeField] private float stopDelay;
    [SerializeField] private bool isInside;
    [SerializeField] private GameObject sceneCam;
    [SerializeField] private GameObject playerCam;

    ThirdPersonControllerNEW controller;
    PlayerInput playerInput;

    void Start()
    {
        controller = player.GetComponent<ThirdPersonControllerNEW>();
        playerInput = player.GetComponent<PlayerInput>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            isInside = true;

            StartCoroutine(StopAuri());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInside = false;
    }

    public IEnumerator StopAuri()
    {
        sceneCam.SetActive(true);
        playerCam.SetActive(false);
        yield return new WaitForSeconds(stopDelay);
        playerInput.actions.Disable(); 
        player.transform.LookAt(speaker.transform);   
        
        yield return new WaitForSeconds(waitTimer);
        playerInput.actions.Enable();
        sceneCam.SetActive(false);
        playerCam.SetActive(true);
        Destroy(this);
    }
}

