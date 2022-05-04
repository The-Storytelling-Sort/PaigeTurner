using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalLightSwitch : MonoBehaviour
{
    private int lightNumber;
    
    public Animator directLight;


    void Start()
    {
        lightNumber = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (lightNumber == 0)
            {
                directLight.Play("Archives_to_Drama");
                lightNumber = 1;
                StartCoroutine(TriggerFreeze());
            }
            else if (lightNumber == 1)
            {
                directLight.Play("Drama_to_Archives");
                lightNumber = 0;
                StartCoroutine(TriggerFreeze());
            }
        }
    }

    IEnumerator TriggerFreeze()
    {
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(5f);
        GetComponent<Collider>().enabled = true;
    }
}
