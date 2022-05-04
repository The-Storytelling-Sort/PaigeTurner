using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWMusicCue : MonoBehaviour
{
    [SerializeField] private AudioSource music;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            music.Play();
        }
    }
}
