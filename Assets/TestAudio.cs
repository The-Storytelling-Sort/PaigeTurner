using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudio : MonoBehaviour
{
    [SerializeField] private AudioSource line;
    [SerializeField] private AudioSource music;
    [SerializeField] private float delayTime;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) ;
        {
            line.Play();

            if (music)
            {
                StartCoroutine(PlayMusic());
            }
        }
    }

    public IEnumerator PlayMusic()
    {
        yield return new WaitForSeconds(delayTime);
        music.Play();
    }
}
