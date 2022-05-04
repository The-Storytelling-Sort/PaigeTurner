using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBookScript : MonoBehaviour
{
    //private Rigidbody rigidbody;
    //public GameObject BookCover;
    [SerializeField] private Animator bookCoverAnim = null;
    [SerializeField] private bool openBookHorizontal = false;
    [SerializeField] private bool openBookVertical = false;
    void Awake()
    {
        gameObject.tag = "Book";
        //rigidbody = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openBookHorizontal)
            {
                bookCoverAnim.Play("BookOpenFull", 0, 0.0f);
                gameObject.SetActive(false);
            }
            if(openBookVertical)
            {
                bookCoverAnim.Play("BookOpenVertical", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
    //void OnCollisionEnter(Collision collision)
    //{
        
            //Debug.Log("I RAN INTO PLAYER");
            //BookCover.transform.Rotate(0f, 0f, 90f * Time.deltaTime);
            //Quaternion rotation = Quaternion.Euler(0, 0, 90f);
        
    //}
}
