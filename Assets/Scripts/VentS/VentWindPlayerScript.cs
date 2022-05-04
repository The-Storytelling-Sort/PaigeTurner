using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Attach this script to the player.
public class VentWindPlayerScript : MonoBehaviour
{
    public bool inVentZone = false;
    [HideInInspector]
    public GameObject ventWindZone;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "WindZone")
        {
            ventWindZone = collider.gameObject;
            inVentZone = true;
        }
        if (collider.gameObject.tag == "WindZone")
        {
            if (ventWindZone != null)
            { 
           
                if (collider.gameObject == ventWindZone)
                {
                    Debug.Log("This is the same Vent");
                    return;
                }
                else
                {
                    ventWindZone = null;
                    ventWindZone = collider.gameObject;
                    Debug.Log("This is a new vent");
                }
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "WindZone")
        {
            inVentZone = false;
            
        }
    }
}

