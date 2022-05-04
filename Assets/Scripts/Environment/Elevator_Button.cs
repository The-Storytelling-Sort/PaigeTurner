using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator_Button : MonoBehaviour
{
    public Elevator elevator;
    public Mover mover;
    AudioSource audioSource;
    public AudioClip buttonPing;
    public AudioClip elevatorThud;
    public AudioClip elevatorDoorSound;
    public AudioClip elevatorGateSound;

    public Animator gateShutter;
    public Animator elevatorDoor;
    
    [SerializeField] private Animator sceneTransition;
    [SerializeField] private int fadeTime;

    public LevelLoader levelLoader;
    public UnlockAbility unlockAbility;

    public SaveProgress saveProgress;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(ElevatorSeq());
            StartCoroutine(DisableButton());
            PlaySound(buttonPing);
            //set new start position inside elevator on next load of archives
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    IEnumerator ElevatorSeq()
    {
        if (SceneManager.GetActiveScene().name == "Archives" && !unlockAbility.frogJumpUnlocked)
        {
            gateShutter.Play("Gate_Close");
            PlaySound(elevatorGateSound);
            yield return new WaitForSeconds(1.5f);
            elevatorDoor.Play("Elevator_DoorClose");
            PlaySound(elevatorDoorSound);
            yield return new WaitForSeconds(1.75f);
            
            levelLoader.LoadLevel("NorthWing");

        }
        
        if (SceneManager.GetActiveScene().name == "NorthWing" && unlockAbility.frogJumpUnlocked)
        {
            gateShutter.Play("Gate_Close");
            PlaySound(elevatorGateSound);
            yield return new WaitForSeconds(1.5f);
            elevatorDoor.Play("Elevator_DoorClose");
            PlaySound(elevatorDoorSound);
            yield return new WaitForSeconds(1.75f);
            
            saveProgress.SetProgress("NorthWing", 1);
            levelLoader.LoadLevel("NWtoGAScene");
        }
    }
    
    IEnumerator SwitchSceneForward()
    {
        sceneTransition.Play("A_Transition_FadeOut");
        yield return new WaitForSeconds(fadeTime);

    }
    
    IEnumerator DisableButton()
    {
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(18.0f);
        GetComponent<Collider>().enabled = true;
    }
}
