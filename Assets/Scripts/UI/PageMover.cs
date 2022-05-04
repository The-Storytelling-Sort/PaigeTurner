using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PageMover : MonoBehaviour
{
    public Transform PageArea;
    public GameObject Player;
    public GameObject prevLine;
    public GameObject currentLine;

    void OnTriggerEnter()
    {
        Player.transform.position = PageArea.transform.position;
        prevLine.SetActive(false);
        currentLine.SetActive(true);
    }

}
