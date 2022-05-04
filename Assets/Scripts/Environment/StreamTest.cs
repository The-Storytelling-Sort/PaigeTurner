using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamTest : MonoBehaviour
{
    [Header("Section Assets")]

    public GameObject grandOffice;
    public GameObject archives;
    public GameObject dramaSection;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "GNOffice")
        {
            grandOffice.SetActive(true);
            archives.SetActive(false);
        }
        else
        {
            grandOffice.SetActive(false);
            archives.SetActive(true);
        }
    }
}
