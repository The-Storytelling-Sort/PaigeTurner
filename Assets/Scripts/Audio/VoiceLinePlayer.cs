using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class VoiceLinePlayer : MonoBehaviour
{
    AudioSource audioSource;

    BoxCollider triggerBox;

    public AudioClip clip;

    public float delayTimeStart;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        triggerBox = GetComponent<BoxCollider>();
       
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "NorthWing")
        {
            if(NoteHolder.pagesColleted == 6)
            {
                audioSource.enabled = false;
            }
        }
            StartCoroutine(PlayVoiceLine());
    }

    IEnumerator PlayVoiceLine()
    {
        
        yield return new WaitForSeconds(delayTimeStart);
        triggerBox.enabled = false;
        PlaySound(clip);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
