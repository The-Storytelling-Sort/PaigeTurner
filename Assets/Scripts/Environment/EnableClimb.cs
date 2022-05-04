using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableClimb : MonoBehaviour
{
    [SerializeField] private GameObject climbable;

    void Start()
    {
        climbable.SetActive(false);    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            climbable.SetActive(true);
            GetComponent<Collider>().enabled = false;
        }
    }
}
