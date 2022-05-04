using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckPointScript : MonoBehaviour
{
    [SerializeField]
    Animator sceneTransition;
    public Transform checkPointRespawnPosition;
    public GameObject Player;
    public GameObject PlayerModel;
    public bool RespawnCalled;

    AuriHealthNEW AuriHealthScript;

    void Awake()
    {
        AuriHealthScript = GetComponent<AuriHealthNEW>();
    }
    public void OnImmediateRespawn()
    {
        Player.transform.position = checkPointRespawnPosition.position;
        PlayerModel.transform.position = checkPointRespawnPosition.position;
        AuriHealthScript.CurrentLives --;
        Debug.Log("Triggered Imediate REspawn");
        sceneTransition.Play("A_Transition_FadeIn");
        Player.GetComponent<ThirdPersonControllerNEW>().moveSpeed = 8.0f;
        Player.GetComponent<ThirdPersonControllerNEW>().isSlowed = false;
        Player.GetComponent<AnimatorManagerNEW>().SetGroundedAnimation();
        Player.GetComponent<PlayerInput>().actions.Enable();
    }

    public void OnDeathRespawn()
    {
        Player.transform.position = checkPointRespawnPosition.position;
        PlayerModel.transform.position = checkPointRespawnPosition.position;
        AuriHealthScript.Heart1.SetActive(true);
        AuriHealthScript.Heart2.SetActive(true);
        AuriHealthScript.Heart3.SetActive(true);
        AuriHealthScript.Lives = 3;
        AuriHealthScript.CurrentLives = 3;
        Player.GetComponent<ThirdPersonControllerNEW>().moveSpeed = 8.0f;
        Player.GetComponent<ThirdPersonControllerNEW>().isSlowed = false;
        sceneTransition.Play("A_Transition_FadeIn");
        Player.GetComponent<AnimatorManagerNEW>().SetGroundedAnimation();
        Player.GetComponent<PlayerInput>().actions.Enable();
    }
    public void SetCheckPoint(Collider collider)
    {
        checkPointRespawnPosition = collider.gameObject.transform;
    }


    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "CheckPoint")
        {
            if (checkPointRespawnPosition == null)
            {
                checkPointRespawnPosition = collider.gameObject.transform;
                Debug.Log("CheckPointSet!");
            }
            else
            {
                if(collider.gameObject.transform == checkPointRespawnPosition)
                {
                    Debug.Log("This is the same Checkpoint");
                    return;
                }
                else
                {
                    checkPointRespawnPosition = null;
                    checkPointRespawnPosition = collider.gameObject.transform;
                    Debug.Log("This is a new Checkpoint");
                }
            }
        }

    }
    IEnumerator respawnFade()
    {
        sceneTransition.Play("A_Transition_FadeOut");
        yield return new WaitForSeconds(2f);
        sceneTransition.Play("A_Transition_FadeIn");
    }
}
