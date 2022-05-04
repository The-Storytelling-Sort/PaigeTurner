using UnityEngine;

public class SubtractLife : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    AuriHealthNEW auriHealth;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !auriHealth.isInvulnerable)
        {
            if(auriHealth.CurrentLives >= 2)
            {
                auriHealth.CurrentLives--;
                auriHealth.elapsedTimeHealthScript = 0;
                auriHealth.isInvulnerable = true;
                Player.GetComponent<AnimatorManagerNEW>().SetHitAnimation();
                GetComponentInParent<BookProjectile>().SendToPile();
            }
            else if (auriHealth.CurrentLives == 1)
            {
                auriHealth.CurrentLives--;
                auriHealth.elapsedTimeHealthScript = 0;
                auriHealth.isInvulnerable = true;
                GetComponentInParent<BookProjectile>().SendToPile();
            }
        }

        else
        {
            Debug.Log("Ouch" + other.gameObject);
            GetComponentInParent<BookProjectile>().SendToPile();
        }
    }

    private void OnCollisionEnter (Collision coll)
    {
        GetComponentInParent<BookProjectile>().SendToPile();
    }
}
