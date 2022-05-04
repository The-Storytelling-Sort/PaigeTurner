using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cue1 : MonoBehaviour
{
    public GameObject Player;

    private SoundtrackManager manager;

    void Start()
    {
        manager = GameObject.FindObjectOfType<SoundtrackManager>();
    }

    void OnTriggerEnter()
    {
        if (manager.GA)
        {
            manager.TO = true;
            manager.GA = false;
            manager.timeElapsed = 0.0f;
        }

        else if (manager.GA == false)
        {
            manager.TO = false;
            manager.GA = true;
            manager.timeElapsed = 0.0f;
        }
    }
}
