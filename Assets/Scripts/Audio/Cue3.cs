using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cue3 : MonoBehaviour
{
    public GameObject Player;

    private SoundtrackManager manager;

    void Start()
    {
        manager = GameObject.FindObjectOfType<SoundtrackManager>();
    }

    void OnTriggerEnter()
    {
        if (manager.DS)
        {
            manager.EV = true;
            manager.DS = false;
            manager.timeElapsed = 0.0f;
        }

        else if (manager.DS == false)
        {
            manager.EV = false;
            manager.DS = true;
            manager.timeElapsed = 0.0f;
        }
    }
}