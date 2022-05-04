using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnerFJCheck : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject turner;

    void Update()
    {
        if (player.GetComponent<UnlockAbility>().frogJumpUnlocked == true)
        {
            Destroy(turner);
        }
    }
}
