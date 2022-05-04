using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiFindNextPoint : MonoBehaviour
{

    public GameObject enemy;

    private void Start()
    {
        enemy.GetComponent<EnemyAiInitialize>();
    }

    public void FindNextPoint()
    {
        int rndIndex = Random.Range(0, enemy.GetComponent<EnemyAiInitialize>().pointList.Length);
        float rndRadius = 4.0f;
        Vector3 rndPosition = Vector3.zero;
        enemy.GetComponent<EnemyAiInitialize>().destinationPosition = enemy.GetComponent<EnemyAiInitialize>().pointList[rndIndex].transform.position + rndPosition;

        if (IsInCurrentRange(enemy.GetComponent<EnemyAiInitialize>().destinationPosition))
        {
            rndPosition = new Vector3(Random.Range(-rndRadius, rndRadius), 0.0f, Random.Range(-rndRadius, rndRadius));
            enemy.GetComponent<EnemyAiInitialize>().destinationPosition = enemy.GetComponent<EnemyAiInitialize>().pointList[rndIndex].transform.position + rndPosition;
            Vector3 targetPosition = enemy.GetComponent<EnemyAiInitialize>().destinationPosition;
            //UpdateTargets(targetPosition);

        }
    }
    protected bool IsInCurrentRange(Vector3 pos)
    {
        float xPos = Mathf.Abs(pos.x - transform.position.x);
        float zPos = Mathf.Abs(pos.z - transform.position.z);

        if (xPos <= 5 && zPos <= 5)

            return true;

        return false;

    }
}
