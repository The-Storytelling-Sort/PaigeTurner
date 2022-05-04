using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoKeyPress : MonoBehaviour
{
    [SerializeField]
    private Animator pianoKey;

    [SerializeField]
    private AudioClip keySound;

    AudioSource audioSource;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Prop")
        {
            pianoKey.Play("A_Piano_Pressed");
            PlaySound(keySound);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Prop")
        {
            pianoKey.Play("A_Piano_Released");
            audioSource.Stop();
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
