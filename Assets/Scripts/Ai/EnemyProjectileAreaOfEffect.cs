using System.Collections;
using UnityEngine;

public class EnemyProjectileAreaOfEffect : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, 5.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && player.GetComponent<ThirdPersonControllerNEW>().isSlowed == false)
        {
            StartCoroutine(player.GetComponent<ThirdPersonControllerNEW>().Slowdown());
        }
        else if(other.gameObject.tag == "Player" && player.GetComponent<ThirdPersonControllerNEW>().isSlowed == true)
        {
            StartCoroutine(RegularSpeed());
        }
    }
    IEnumerator RegularSpeed()
    {
        if (player.GetComponent<ThirdPersonControllerNEW>().isSlowed == true)
        {
            yield return new WaitForSeconds(3);
            player.GetComponent<ThirdPersonControllerNEW>().isSlowed = false;
            player.GetComponent<ThirdPersonControllerNEW>().moveSpeed = 8f;
            
        }
    }
}
