using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCollideSFX : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip collideSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Ground" || other.collider.tag == "Prop")
        {
            PlaySound(collideSound);
        }
    }
}
