using System;
using UnityEngine.AI;
using UnityEngine;

public class EnemyAiChaseState : MonoBehaviour
{
    public GameObject enemy;
    EnemyAiInitialize AiInitialize;
    public event EventHandler OnEnemyAttacksPlayer;
    public event EventHandler OnEnemyLosesPlayer;

    private void Start()
    {
        enemy.GetComponent<EnemyAiInitialize>();
        AiInitialize = GetComponent<EnemyAiInitialize>();
    }
    public void UpdateChaseState()
    {
        AiInitialize.agent.speed = 6f;
        AiInitialize.destinationPosition = AiInitialize.playerTransform.position;

        float distance = Vector3.Distance(transform.position, AiInitialize.playerTransform.position);
        if (AiInitialize.MeleeEnemy == true)
        {
            if (distance <= 7.0f)
            {
                OnEnemyAttacksPlayer?.Invoke(this, EventArgs.Empty);
            }
            else if (distance >= 15.0f)
            {
                OnEnemyLosesPlayer?.Invoke(this, EventArgs.Empty);
            }

            AiInitialize.agent.SetDestination(AiInitialize.destinationPosition);
        }

        if (AiInitialize.RangedEnemy == true)
        {

        }
    }
}
