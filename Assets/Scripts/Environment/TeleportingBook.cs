using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingBook : MonoBehaviour
{

    public Transform worldArea;
    public GameObject Player;
    public GameObject PlayerModel;

    AudioSource audioSource;
    public AudioClip teleportSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {     
            Player.transform.position = worldArea.transform.position;
            PlayerModel.transform.position = worldArea.transform.position;
            PlaySound(teleportSound);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

}