using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveTurn : MonoBehaviour
{
    public Animator valve;
    public Animator floodWater;

    public GameObject smallWaterfall;
    public GameObject mistParticle;
    public Light signalLight;
    public GameObject roomLight;

    public GameObject cutsceneCam;
    public GameObject playerCam;

    static int valveNumber = 0;

    public bool isDrained = false;

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip valveSound;

    [SerializeField] private AudioSource waterFall;

    [SerializeField] private GameObject player;

    ThirdPersonControllerNEW controller;
    AnimatorManagerNEW animatorManagerNew;
    Animator animator;

    void Start()
    {
        controller = player.GetComponent<ThirdPersonControllerNEW>();
        animatorManagerNew = player.GetComponent<AnimatorManagerNEW>();
        animator = player.GetComponent<Animator>();
    }

    private void Update()
    {
        /*
        if (animator.GetBool("Hang"))
        {
            controller.gravity = 0;
            controller.verticalVelocity = 0;
            player.transform.position = transform.position;
        }
        */
    }

    //floodwater height reduces when valves are touched, changes nearby light color
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //animatorManagerNew.SetHangAnimation();
            valve.Play("A_Valve_Turn");
            GetComponent<Collider>().enabled = false;
            valveNumber += 1;

            if (valveNumber == 1)
            {
                StartCoroutine(Cutscene());
                StartCoroutine(FreezePlayer());
                ChangeLight();
                playerCam.SetActive(false);
                floodWater.Play("A_Flood_Drain_01");
                smallWaterfall.SetActive(false);
                PlaySound(valveSound);
            }
            else if (valveNumber == 2)
            {
                floodWater.Play("A_Flood_Drain_02");
                ChangeLight();
                PlaySound(valveSound);
            }
            else if (valveNumber == 3)
            {
                StartCoroutine(Cutscene());
                StartCoroutine(RoomAccess());
                StartCoroutine(FreezePlayer());
                ChangeLight();
                playerCam.SetActive(false);
                floodWater.Play("A_Flood_Drain_03");
                isDrained = true;
                PlaySound(valveSound);
                waterFall.Stop();
            }
        }
    }

    IEnumerator Cutscene()
    {
        cutsceneCam.SetActive(true);
        yield return new WaitForSecondsRealtime(5.0f);
        playerCam.SetActive(true);
        yield return new WaitForSecondsRealtime(0.25f);
        cutsceneCam.SetActive(false);
        //animator.SetBool("Hang", false);
    }

    IEnumerator RoomAccess()
    {
        yield return new WaitForSecondsRealtime(3.0f);
        mistParticle.SetActive(false);
        yield return new WaitForSecondsRealtime(0.25f);
        roomLight.SetActive(true);
    }

    IEnumerator FreezePlayer()
    {
        controller.FreezePlayer();
        yield return new WaitForSeconds(4.5f);
        controller.ResumePlayer();
    }

    void ChangeLight()
    {
        signalLight.color = Color.green;
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
