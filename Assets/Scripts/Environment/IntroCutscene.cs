using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IntroCutscene : MonoBehaviour
{

    public GameObject playerCam;
    public GameObject introCam;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float waitTime;
    
    [SerializeField]
    private float stoppedDelay;

    ThirdPersonControllerNEW controller;
    PlayerInput playerInput;


    void Start()
    {
        controller = player.GetComponent<ThirdPersonControllerNEW>();
        playerInput = player.GetComponent<PlayerInput>();
    }

    // play intro sequence and freeze player for a duration
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Environment")
        {
            StartCoroutine(IntroSequence());
            //StartCoroutine(FreezePlayer());
            GetComponent<Collider>().enabled = false;
        }
    }
    IEnumerator IntroSequence()
    {
        yield return new WaitForSeconds(stoppedDelay);
        playerInput.actions.Disable();
        introCam.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        introCam.SetActive(false);
        playerInput.actions.Enable();

    }

    IEnumerator FreezePlayer()
    {
        controller.FreezePlayer();
        yield return new WaitForSeconds(waitTime);
        controller.ResumePlayer();
    }
}
