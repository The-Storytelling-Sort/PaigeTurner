using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Die();
        }

        Debug.Log("Projectile Collision with " + other.gameObject);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        LightableScript lite = other.GetComponent<LightableScript>();
        if (lite != null)
        {
            lite.TurnOnLight();
        }
    }
}
