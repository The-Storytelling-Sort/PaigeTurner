using System;
using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class EnemyAiAttackState : MonoBehaviour
{
    public GameObject enemy;

    EnemyAiInitialize AiInitialize;

    public event EventHandler OnEnemyAttacksPlayer;
    public event EventHandler OnEnemyShootProjectile;
    public event EventHandler OnEnemyLosesPlayer;
    public event EventHandler OnPlayerDefeated;
    public event EventHandler OnEnemyMeleeAttacks;
    public event EventHandler OnEnemyRetreat;

    public float rangedStopDistance;
    public float rangedRetreatDistance;
    private void Start()
    {
        enemy.GetComponent<EnemyAiInitialize>();
        AiInitialize = GetComponent<EnemyAiInitialize>();
    }
    public void UpdateAttackState()
    {
        AiInitialize.currentSpeed = 100f;
        AiInitialize.destinationPosition = AiInitialize.playerTransform.position;
        Vector3 targetPosition = AiInitialize.destinationPosition + new Vector3(1, 0, 1);

        float distance = Vector3.Distance(transform.position, AiInitialize.playerTransform.position);
        
        
        
        if(AiInitialize.RangedEnemy == true)
        {
            if (distance <= rangedStopDistance && distance > rangedRetreatDistance)
            {

                
                Quaternion targetRotation = Quaternion.LookRotation(AiInitialize.destinationPosition - transform.position, new Vector3(0,0,0));
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * AiInitialize.currentRotationSpeed);

                OnEnemyAttacksPlayer?.Invoke(this, EventArgs.Empty);
            }
            if(distance < rangedRetreatDistance)
            {
                enemy.GetComponent<EnemyAiInitialize>().currentSpeed = 20f;
                enemy.GetComponent<RangedAiAnimationManager>().SetDodgeAnimation();
                enemy.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * Time.deltaTime * AiInitialize.currentSpeed, ForceMode.Impulse);
                OnEnemyRetreat?.Invoke(this, EventArgs.Empty);

            }
            if (distance >= 20)
            {
                OnEnemyLosesPlayer?.Invoke(this, EventArgs.Empty);
            }
            if (enemy.GetComponent<EnemyAiInitialize>().playerTransform.position == null)
            {
                OnPlayerDefeated?.Invoke(this, EventArgs.Empty);
            }

            AiInitialize.bulletSpawnPoint.transform.LookAt(AiInitialize.playerTransform.transform.position);

            enemy.GetComponent<RangedAiAnimationManager>().SetAttackAnimation();
            StartCoroutine(DelayAnimation());

            OnEnemyShootProjectile?.Invoke(this, EventArgs.Empty);
        }

        if(enemy.GetComponent<EnemyAiInitialize>().MeleeEnemy == true)
        {
            if (distance >= 1.5f && distance < 10)
            {
                Quaternion targetRotation = Quaternion.LookRotation(AiInitialize.destinationPosition - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * AiInitialize.currentRotationSpeed);

                AiInitialize.agent.SetDestination(AiInitialize.destinationPosition + new Vector3(1.5f, 0 , 1.5f));

                transform.LookAt(new Vector3(AiInitialize.playerTransform.transform.position.x, 0, AiInitialize.playerTransform.transform.position.z));

                OnEnemyMeleeAttacks?.Invoke(this, EventArgs.Empty);
                OnEnemyAttacksPlayer?.Invoke(this, EventArgs.Empty);

            }
            else if (distance >= 11)
            {
                OnEnemyLosesPlayer?.Invoke(this, EventArgs.Empty);
            }
            if (AiInitialize.playerTransform.position == null)
            {
                OnPlayerDefeated?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    IEnumerator  DelayAnimation()
    {
        yield return new WaitForSeconds(.75f);
        StopCoroutine(DelayAnimation());
    }
}
