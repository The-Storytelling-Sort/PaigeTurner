using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicLightStick : MonoBehaviour
{
    [SerializeField] private GameObject[] tetheredEnemies;
    [SerializeField] private GameObject light;
    [SerializeField] private int numberEnemies;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            numberEnemies = tetheredEnemies.Length;

            int i = 0;

            while (i < numberEnemies)
            {
                Destroy(tetheredEnemies[i]);
                i++;
            }
            
            light.SetActive(true);
            //Jordan - Line of code to destroy the placeholder cube. Remove this later.
            Destroy(gameObject);
        }
    }
}
