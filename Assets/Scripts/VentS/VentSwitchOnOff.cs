using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentSwitchOnOff : MonoBehaviour
{
    public GameObject On;
    public GameObject Off;

    AudioSource audioSource;
    public AudioClip switchActive;

    public bool isOff;

    //  private VentManager ventmanager;

    [SerializeField] private GameObject[] vents;

    [SerializeField] private GameObject[] ventsNorthWingPuzzle;

    void Start()
    {
        //ventmanager = GameObject.FindObjectOfType<VentManager>();

        audioSource = GetComponent<AudioSource>();

        if (isOff)
        {
           Off.SetActive(true);
           On.SetActive(false);

            for (int i = 0; i < vents.Length; i++)
            {
                vents[i].SetActive(false);
            }

            for (int i = 0; i < ventsNorthWingPuzzle.Length; i++)
            {
                ventsNorthWingPuzzle[i].SetActive(true);
            }
        }
        else if (!isOff)
        {
            Off.SetActive(false);
            On.SetActive(true);

            for (int i = 0; i < vents.Length; i++)
            {
                vents[i].SetActive(true);
            }

            for (int i = 0; i < ventsNorthWingPuzzle.Length; i++)
            {
                ventsNorthWingPuzzle[i].SetActive(false);
            }
        }
    }

    void OnTriggerEnter()
    {
        //  ventmanager.Off = !ventmanager.Off;

        PlaySound(switchActive);

        if (isOff)
        {
            Off.SetActive(false);
            On.SetActive(true);
            isOff = false;

            for (int i = 0; i < vents.Length; i++)
            {
                vents[i].SetActive(true);
            }

            for (int i = 0; i < ventsNorthWingPuzzle.Length; i++)
            {
                ventsNorthWingPuzzle[i].SetActive(false);
            }
        }
        else if (!isOff)
        {
            Off.SetActive(true);
            On.SetActive(false);
            isOff = true;

            for (int i = 0; i < vents.Length; i++)
            {
                vents[i].SetActive(false);
            }

            for (int i = 0; i < ventsNorthWingPuzzle.Length; i++)
            {
                ventsNorthWingPuzzle[i].SetActive(true);
            }
        }
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

}