using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{

    AudioSource audioSource;

    public AudioClip pageTurn1;
    public AudioClip pageTurn2;
    public AudioClip closeBook;

    int soundNumber;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    void RandomGenerate()
    {
        soundNumber = Random.Range (0, 2);
    }

    public void OptionsCreditsBack()
    {
        RandomGenerate();
        if (soundNumber == 0)
        {
            PlaySound(pageTurn1);
        }
        if (soundNumber == 1)
        {
            PlaySound(pageTurn2);
        }
    }

    public void BookClose()
    {
        PlaySound(closeBook);
    }
}
