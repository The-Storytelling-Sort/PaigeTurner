using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    Vector2 movement;
    Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        targetRotation = Quaternion.LookRotation(player.position - transform.position);
        movement = direction;
    }

    private void FixedUpdate()
    {
        /*LanternScript lantern = player.GetComponent<LanternScript>();

        if (lantern.isLantern == true)
        {
            moveEnemy(movement);
        }*/
    }

    void moveEnemy (Vector2 direction)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, moveSpeed * Time.deltaTime);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
