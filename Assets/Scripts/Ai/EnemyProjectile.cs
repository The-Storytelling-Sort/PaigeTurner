using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField]
    private float LifeTime = 3.0f;

    [SerializeField]
    private int projectileSpeed;
    [SerializeField]
    private int projectileArc;
    [SerializeField]
    private GameObject areaofEffect;
    [SerializeField]
    GameObject Player;
    AuriHealthNEW auriHealth;

    

    public int damage = 1;

    // Start is called before the first frame update

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
        rb.AddForce(transform.up * projectileArc, ForceMode.Impulse);

        Player = GameObject.FindGameObjectWithTag("Player");
        auriHealth = Player.GetComponent<AuriHealthNEW>();

        
        Destroy(gameObject, LifeTime);
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            Instantiate(areaofEffect, collision.contacts[0].point, collision.transform.rotation);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player" && !auriHealth.isInvulnerable)
        {
            if (auriHealth.CurrentLives >= 2)
            {
                auriHealth.elapsedTimeHealthScript = 0;
                auriHealth.isInvulnerable = true;
                auriHealth.CurrentLives--;
                Player.GetComponent<AnimatorManagerNEW>().SetHitAnimation();
                Debug.Log("Hit the Player");
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else if (auriHealth.CurrentLives == 1)
            {
                auriHealth.elapsedTimeHealthScript = 0;
                auriHealth.isInvulnerable = true;
                auriHealth.CurrentLives--;
                Debug.Log("Hit the Player");
                Destroy(gameObject);
            }
            

        }
        else if(collision.gameObject.tag != "Ground" && collision.gameObject.tag != "Player")
        {
            Debug.Log("Didnt hit the ground or the player");
            Destroy(gameObject);
        }
    }

}
