using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WorldTeleporter4 : MonoBehaviour
{
    public Transform worldArea;
    public GameObject Player;
    public GameObject Page;

    private CameraChecker camerachecker;

    void Awake()
    {
        camerachecker = GameObject.FindObjectOfType<CameraChecker>();
    }

    void OnTriggerEnter()
    {
        //camerachecker.is3D = true;
        camerachecker.flipped8to9 = true;
        Debug.Log("Collided!");
        //Player.transform.position = worldArea.transform.position;                 
    }

}