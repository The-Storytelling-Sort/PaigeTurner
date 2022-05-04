using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOpenV2 : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float forceAdded = 20f;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Book";
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
         rigidbody.AddForce(Vector3.up * forceAdded);
        
    }
}
