using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtProtoMovement : MonoBehaviour
{
    public float speed = 5;
    Vector3 velocity;


    void Update()
    {
        velocity.x = Input.GetAxis("Vertical") * speed * -Time.deltaTime;
        velocity.y = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(velocity.x, velocity.z, velocity.y);
    }
}

