using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiFSMUpdate : EnemyAiInitialize
{

    
    protected override void FSMUpdate()
    {
        switch (currentState)
        {
            case FSMState.Patrol: GetComponent<EnemyAiPatrolState>().UpdatePatrolState(); break;
            case FSMState.Chase: GetComponent<EnemyAiChaseState>().UpdateChaseState(); break;
            case FSMState.Attack: GetComponent<EnemyAiAttackState>().UpdateAttackState(); break;
            case FSMState.Dead: GetComponent<EnemyAiDeadState>().UpdateDeadState(); break;
        }

        elapsedTime += Time.deltaTime;

        if (bDead == true)
        {
            currentState = FSMState.Dead;
        }
    }
    private void Update()
    {
       
    }
}
