using UnityEngine;

public class EnemyAiMelee : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField]
    GameObject Player;
    AuriHealthNEW auriHealth;
    [SerializeField]
    AudioSource hitaudioSource;
    [SerializeField]
    AudioSource deathaudioSource;


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        auriHealth = Player.GetComponent<AuriHealthNEW>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
      if (other.gameObject.tag == "Player" && !auriHealth.isInvulnerable)
      {
            if (auriHealth.CurrentLives >= 2 )
            {
                auriHealth.elapsedTimeHealthScript = 0;
                auriHealth.isInvulnerable = true;
                auriHealth.CurrentLives--;
                Player.GetComponent<AnimatorManagerNEW>().SetHitAnimation();
                hitaudioSource.Play();
                enemy.GetComponent<EnemyAiInitialize>().elapsedTimeMelee = 0;
                
            }
            else if (auriHealth.CurrentLives == 1 )
            {
                auriHealth.elapsedTimeHealthScript = 0;
                auriHealth.isInvulnerable = true;
                auriHealth.CurrentLives--;
                hitaudioSource.Play();
                deathaudioSource.Play();
                enemy.GetComponent<EnemyAiInitialize>().elapsedTimeMelee = 0;
                Debug.Log("Elapsed Time Reset");
            }
      }
        
    }

}
