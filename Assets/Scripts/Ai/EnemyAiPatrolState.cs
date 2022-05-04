using System;
using UnityEngine.AI;
using UnityEngine;

public class EnemyAiPatrolState : MonoBehaviour
{
    public GameObject enemy;

    EnemyAiInitialize AiInitialize;

    public event EventHandler OnPatrolPointFound;
    public event EventHandler OnEnemyChasesPlayer;
    public event EventHandler OnRangedEnemyAttackPlayer;

    private void Start()
    {
        enemy.GetComponent<EnemyAiInitialize>();
        AiInitialize = GetComponent<EnemyAiInitialize>();
    }

    public void UpdatePatrolState()
    {
        GameObject objectPlayer = GameObject.FindGameObjectWithTag("Player");

        if (AiInitialize.MeleeEnemy == true)
        {
            AiInitialize.agent.speed = 3.5f;
            if (Vector3.Distance(transform.position, AiInitialize.destinationPosition) <= 2.5f)
            {
                OnPatrolPointFound?.Invoke(this, EventArgs.Empty);
                enemy.GetComponent<MeleeAiAnimationManager>().SetWalkAnimation();
            }

            else if (Vector3.Distance(transform.position, AiInitialize.playerTransform.position) <= 12.0f)
            {
                OnEnemyChasesPlayer?.Invoke(this, EventArgs.Empty);
            }

           
            Quaternion targetRotation = Quaternion.LookRotation(AiInitialize.destinationPosition - transform.position, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * AiInitialize.currentRotationSpeed);

            AiInitialize.agent.SetDestination(AiInitialize.destinationPosition);

            
            
        }
           
        if (AiInitialize.RangedEnemy == true)
        {
            if (Vector3.Distance(transform.position, AiInitialize.destinationPosition) <= 5.0f)
            {
                enemy.GetComponent<Rigidbody>().velocity = Vector3.zero;
                enemy.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                OnPatrolPointFound?.Invoke(this, EventArgs.Empty);
            }

            else if (Vector3.Distance(transform.position, AiInitialize.playerTransform.position) <= 13.0f) 
            {
                OnRangedEnemyAttackPlayer?.Invoke(this, EventArgs.Empty);
            }

            
            Quaternion targetRotation = Quaternion.LookRotation(AiInitialize.destinationPosition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * AiInitialize.currentRotationSpeed);

            
            AiInitialize.agent.SetDestination(AiInitialize.destinationPosition);
            enemy.GetComponent<RangedAiAnimationManager>().SetWalkAnimation();
        }
    }
}
