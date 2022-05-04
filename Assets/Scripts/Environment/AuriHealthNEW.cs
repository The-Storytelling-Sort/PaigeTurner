using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AuriHealthNEW : MonoBehaviour
{
    [SerializeField]
    Animator sceneTransition;
    public GameObject Player;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public int Lives;
    public int CurrentLives;
    public bool isInvulnerable;
    public float elapsedTimeHealthScript;

    public string NumLives => $"PlayerLives-{CurrentLives}";

    CheckPointScript checkPointScript;

    void Awake()
    {
        checkPointScript = GetComponent<CheckPointScript>();
    }

    void Update()
    {
        switch(CurrentLives)
        {
            case 3: FullHealth(); break;
            case 2: oneHit(); break;
            case 1: twoHits(); break;
            case 0: threeHits(); break;
        }
        elapsedTimeHealthScript += Time.deltaTime;

        if(isInvulnerable == true && elapsedTimeHealthScript >= 3)
        {
            isInvulnerable = false;
        }
    }
    void FullHealth()
    {
        Heart3.SetActive(true);
        Heart2.SetActive(true);
        Heart1.SetActive(true);
    }
    void oneHit()
    {
        Heart3.SetActive(false);
        Heart2.SetActive(true);
        Heart1.SetActive(true);

    }
    void twoHits()
    {
        Heart3.SetActive(false);
        Heart2.SetActive(false);
        Heart1.SetActive(true);
    }
    void threeHits()
    {
        Heart3.SetActive(false);
        Heart2.SetActive(false);
        Heart1.SetActive(false);
        Player.GetComponent<AnimatorManagerNEW>().SetDeadAnimation();
        Player.GetComponent<PlayerInput>().actions.Disable();
        sceneTransition.Play("A_Transition_FadeOut");
        StartCoroutine(delayRespawn());
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("KillZone") && !isInvulnerable)
        {
            isInvulnerable = true;
            Player.GetComponent<AnimatorManagerNEW>().SetDeadAnimation();
            Player.GetComponent<PlayerInput>().actions.Disable();
            sceneTransition.Play("A_Transition_FadeOut");
            if (CurrentLives > 1)
            {
                StartCoroutine(delayImmediateRespawn());
            }
            if (CurrentLives == 1)
            {
                StartCoroutine(delayRespawn());
            }
            
        }
    }
    public IEnumerator delayRespawn()
    {
        yield return new WaitForSeconds(2f);
        checkPointScript.OnDeathRespawn();
        StopCoroutine(delayRespawn());
    }
    public IEnumerator delayImmediateRespawn()
    {
        yield return new WaitForSeconds(2f);
        checkPointScript.OnImmediateRespawn();
        StopCoroutine(delayImmediateRespawn());
    }
}
