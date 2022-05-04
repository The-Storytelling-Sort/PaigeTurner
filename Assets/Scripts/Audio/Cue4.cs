using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cue4 : MonoBehaviour
{
    public GameObject Player;

    public AudioSource PaigeVO2;

    void Start()
    {

    }

    void OnTriggerExit()
    {
        StartCoroutine(PlayLine());
    }

    IEnumerator PlayLine()
    {
        PaigeVO2.Play();
        yield return new WaitForSeconds(10.0f);
        Destroy(this);
    }
}
