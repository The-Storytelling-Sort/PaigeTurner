using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiPlayerStandIn : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
