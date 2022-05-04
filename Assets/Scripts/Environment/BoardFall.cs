using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardFall : MonoBehaviour
{

    public GameObject Board;

    void Start()
    {
        Board.GetComponent<Animator>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Board.GetComponent<Animator>().enabled = true;
    }
}
