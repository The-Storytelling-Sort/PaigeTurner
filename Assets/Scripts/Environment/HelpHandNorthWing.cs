using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpHandNorthWing : MonoBehaviour
{
    [SerializeField] private GameObject TPbook1;
    [SerializeField] private GameObject TPbook2;

    [SerializeField] private GameObject poof1;
    [SerializeField] private GameObject poof2;


    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Timing());
    }

    IEnumerator Timing()
    {
        yield return new WaitForSeconds(8.0f);
        TPbook1.SetActive(true);
        poof1.SetActive(true);
        yield return new WaitForSeconds(8.0f);
        TPbook2.SetActive(true);
        poof2.SetActive(true);
    }
}
