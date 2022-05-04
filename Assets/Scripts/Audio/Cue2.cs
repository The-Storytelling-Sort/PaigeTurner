using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cue2 : MonoBehaviour
{
    public GameObject Player;

    private SoundtrackManager manager;

    void Start()
    {
        manager = GameObject.FindObjectOfType<SoundtrackManager>();
    }

    void OnTriggerEnter()
    {
        if (manager.EV)
        {
            manager.GA = true;
            manager.EV = false;
            manager.timeElapsed = 0.0f;
        }

        else if (manager.EV == false)
        {
            manager.GA = false;
            manager.EV = true;
            manager.timeElapsed = 0.0f;
        }
    }
}
