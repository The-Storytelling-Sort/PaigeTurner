using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiEvents : MonoBehaviour
{
    public GameObject enemy;

    EnemyAiInitialize aiInitialize;


    void Start()
    {
        aiInitialize = GetComponent<EnemyAiInitialize>();

        EnemyAiPatrolState enemyAiPatrolState = GetComponent<EnemyAiPatrolState>();
        enemyAiPatrolState. OnPatrolPointFound += EnemyAi_OnPatrolPointFound;
        enemyAiPatrolState.OnEnemyChasesPlayer += EnemyAi_OnEnemyChasesPlayer;
        enemyAiPatrolState.OnRangedEnemyAttackPlayer += EnemyAi_OnRangedEnemyAttackPlayer;

        EnemyAiAttackState enemyAiAttackState = GetComponent<EnemyAiAttackState>();
        enemyAiAttackState.OnEnemyAttacksPlayer += EnemyAi_OnEnemyAttacksPlayer;
        enemyAiAttackState.OnEnemyLosesPlayer += EnemyAi_OnEnemyLosesPlayer;
        enemyAiAttackState.OnEnemyShootProjectile += EnemyAi_OnEnemyShootProjectile;
        enemyAiAttackState.OnEnemyMeleeAttacks += EnemyAi_OnEnemyMeleeAttacks;
        enemyAiAttackState.OnPlayerDefeated += EnemyAi_OnPlayerDefeated;
        enemyAiAttackState.OnEnemyRetreat += EnemyAi_OnEnemyRetreat;

        EnemyAiChaseState enemyAiChaseState = GetComponent<EnemyAiChaseState>();
        enemyAiChaseState.OnEnemyAttacksPlayer += EnemyAi_OnEnemyAttacksPlayer;
        enemyAiChaseState.OnEnemyLosesPlayer += EnemyAi_OnEnemyLosesPlayer;
    }
    void EnemyAi_OnPatrolPointFound(object sender, EventArgs e)
    {
        enemy.GetComponent<EnemyAiFindNextPoint>().FindNextPoint();
    }
    void EnemyAi_OnEnemyChasesPlayer(object sender, EventArgs e)
    {
        enemy.GetComponent<MeleeAiAnimationManager>().SetRunAnimation();
        aiInitialize.currentState = EnemyAiInitialize.FSMState.Chase;

    }
    void EnemyAi_OnEnemyAttacksPlayer(object sender, EventArgs e)
    {
        aiInitialize.currentState = EnemyAiInitialize.FSMState.Attack;
    }
    void EnemyAi_OnEnemyLosesPlayer(object sender, EventArgs e)
    {
        enemy.GetComponent<EnemyAiFindNextPoint>().FindNextPoint();
        aiInitialize.currentState = EnemyAiInitialize.FSMState.Patrol;
    }
    void EnemyAi_OnEnemyShootProjectile(object sender, EventArgs e)
    {
        transform.LookAt(new Vector3(aiInitialize.playerTransform.transform.position.x, 0, aiInitialize.playerTransform.transform.position.z));
        if (aiInitialize.elapsedTimeRanged >= aiInitialize.shootRate)
            {
            Instantiate(aiInitialize.enemyProjectile,aiInitialize.bulletSpawnPoint.position, aiInitialize.bulletSpawnPoint.rotation);
                aiInitialize.elapsedTimeRanged = 0.0f;
            }
    }
    void EnemyAi_OnRangedEnemyAttackPlayer(object sender, EventArgs e)
    {
        aiInitialize.currentState = EnemyAiInitialize.FSMState.Attack;
    }
    void EnemyAi_OnEnemyMeleeAttacks(object sender, EventArgs e)
    {
        if (aiInitialize.elapsedTimeMelee >= aiInitialize.meleeHitDelay)
        {
            enemy.GetComponent<MeleeAiAnimationManager>().SetAttackAnimation();
            aiInitialize.elapsedTimeMelee = 0.0f;
        }


    }
    void EnemyAi_OnPlayerDefeated(object sender, EventArgs e)
    {
        aiInitialize.playerTransform = null;
        enemy.GetComponent<EnemyAiFindNextPoint>().FindNextPoint();
    }

    void EnemyAi_OnEnemyRetreat(object sender, EventArgs e)
    {
        StopCoroutine(Delay(0));
        StartCoroutine(Delay(.2f));
        aiInitialize.currentState = EnemyAiInitialize.FSMState.Attack;

    }
    IEnumerator Delay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        enemy.GetComponent<Rigidbody>().velocity = Vector3.zero;
        enemy.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        yield break;
    }
        void OnDestroy()
    {
        EnemyAiPatrolState enemyAiPatrolState = GetComponent<EnemyAiPatrolState>();
        enemyAiPatrolState.OnPatrolPointFound -= EnemyAi_OnPatrolPointFound;
        enemyAiPatrolState.OnEnemyChasesPlayer -= EnemyAi_OnEnemyChasesPlayer;
        enemyAiPatrolState.OnRangedEnemyAttackPlayer -= EnemyAi_OnRangedEnemyAttackPlayer;

        EnemyAiAttackState enemyAiAttackState = GetComponent<EnemyAiAttackState>();
        enemyAiAttackState.OnEnemyAttacksPlayer -= EnemyAi_OnEnemyAttacksPlayer;
        enemyAiAttackState.OnEnemyLosesPlayer -= EnemyAi_OnEnemyLosesPlayer;
        enemyAiAttackState.OnEnemyShootProjectile -= EnemyAi_OnEnemyShootProjectile;
        enemyAiAttackState.OnEnemyMeleeAttacks -= EnemyAi_OnEnemyMeleeAttacks;
        enemyAiAttackState.OnPlayerDefeated -= EnemyAi_OnPlayerDefeated;
        enemyAiAttackState.OnEnemyRetreat -= EnemyAi_OnEnemyRetreat;

        EnemyAiChaseState enemyAiChaseState = GetComponent<EnemyAiChaseState>();
        enemyAiChaseState.OnEnemyAttacksPlayer -= EnemyAi_OnEnemyAttacksPlayer;
        enemyAiChaseState.OnEnemyLosesPlayer -= EnemyAi_OnEnemyLosesPlayer;

        Debug.Log("I have unsubscribed because i am dead");
    }
}
