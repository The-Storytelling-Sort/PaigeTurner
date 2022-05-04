using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BookTeleporter : MonoBehaviour
{
    //public Transform bookArea;
    public GameObject Player;
    public AudioSource Narration;

    private CameraChecker camerachecker;

        void Awake()
        {
        camerachecker = GameObject.FindObjectOfType<CameraChecker>();
        }
    
        void OnTriggerEnter()
        {
        camerachecker.is2D = true;
        Narration.Play();
        
        //Player.transform.position = bookArea.transform.position;                 
        }
    
}
