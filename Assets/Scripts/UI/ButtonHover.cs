using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{

    Animator buttonAnim;

    AudioSource audioSource;
    public AudioClip hoverSound1;
    public AudioClip hoverSound2;

    int soundNumber;



    void Start()
    {
        buttonAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void RandomGenerate()
    {
        soundNumber = Random.Range (0, 2);
    }

    public void Hover()
    {
        RandomGenerate();
        buttonAnim.Play("Button_Hover");
        {
            if (soundNumber == 0)
            {
                audioSource.PlayOneShot(hoverSound1);
            }
            if (soundNumber == 1)
            {
                audioSource.PlayOneShot(hoverSound2);
            }
        }
    }

    public void Idle()
    {
        buttonAnim.Play("Button_Idle");
    }

}
