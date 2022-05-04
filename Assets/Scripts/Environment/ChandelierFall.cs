using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChandelierFall : MonoBehaviour
{
    private Rigidbody rb;

    public float gravity = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gravity = 10;

            Destroy(gameObject, 5);
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.down * gravity * rb.mass);
    }
}
