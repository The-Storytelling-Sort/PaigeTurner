using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BookDelay : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float dialogueTimer;
    [SerializeField] private GameObject firstLine;
    
    ThirdPersonControllerNEW controller;
    PlayerInput playerInput;
    private void Start()
    {
        controller = player.GetComponent<ThirdPersonControllerNEW>();
        playerInput = player.GetComponent<PlayerInput>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StopAuri());
        }
    }

    public IEnumerator StopAuri()
    {
        playerInput.actions.Disable();
        yield return new WaitForSeconds(dialogueTimer);
        firstLine.SetActive(true);
        playerInput.actions.Enable(); 
    }
}
