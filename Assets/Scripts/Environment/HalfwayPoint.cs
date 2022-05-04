using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfwayPoint : MonoBehaviour
{
    public GameObject oldBook;
    public GameObject newBook;

    void Start()
    {
        oldBook.SetActive(true);
        newBook.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            oldBook.SetActive(false);
            newBook.SetActive(true);
            Destroy(gameObject);
        }
    }
}
