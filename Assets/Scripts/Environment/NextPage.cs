using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPage : MonoBehaviour
{
    [SerializeField]
    private GameObject previousCam;

    BoxCollider box;

    void Start()
    {
        box = GetComponent<BoxCollider>();
    }

    
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            previousCam.SetActive(false);
            box.isTrigger = false;
        }
    }
}
