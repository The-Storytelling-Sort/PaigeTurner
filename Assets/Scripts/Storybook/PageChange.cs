using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PageChange : MonoBehaviour
{
    [SerializeField] private GameObject storybook;
    [SerializeField] private bool[] pageCheck;
    [SerializeField] private Renderer rend;
    [SerializeField] private Material nextPage;
    [SerializeField] private float timer;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (pageCheck[0])
            {
                storybook.GetComponent<BookAnimScript>().FirstAnim();
                StartCoroutine(MaterialSwap());
            }
            
            if (pageCheck[1])
            {
                storybook.GetComponent<BookAnimScript>().SecondAnim();
                StartCoroutine(MaterialSwap());

            }
            
            if (pageCheck[2])
            {
                storybook.GetComponent<BookAnimScript>().ThirdAnim();
                StartCoroutine(MaterialSwap());

            }
            
            if (pageCheck[3])
            {
                storybook.GetComponent<BookAnimScript>().FourthAnim();
                StartCoroutine(MaterialSwap());

            }

            else
            {
                Debug.Log("NoSelection");
            }
        }
    }

    IEnumerator MaterialSwap()
    {
        yield return new WaitForSeconds(timer);
        rend.material = nextPage;
    }
}
