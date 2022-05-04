using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeTrigger : MonoBehaviour
{

    public GameObject playerCam;
    public GameObject challengeCam;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerCam.SetActive(false);
            challengeCam.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerCam.SetActive(true);
            challengeCam.SetActive(false);
        }
    }
}
