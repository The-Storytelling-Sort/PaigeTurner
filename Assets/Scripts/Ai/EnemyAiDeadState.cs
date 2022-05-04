using System;
using UnityEngine;

public class EnemyAiDeadState : MonoBehaviour
{
   public GameObject enemy;


    private void Start()
    {
        enemy.GetComponent<EnemyAiInitialize>();
    }
    public void UpdateDeadState()
    {
        if (enemy.GetComponent<EnemyAiInitialize>().bDead != true)
        {
            enemy.GetComponent<EnemyAiInitialize>().bDead = true;
            Explode();
        }
        else if(enemy.GetComponent<EnemyAiInitialize>().bDead == true)
        {
            Explode();
        }
    }
    protected void Explode()
    {
        Destroy(gameObject, 1.5f);
    }

}
