using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidanceSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject guidanceOne;
    [SerializeField] private GameObject guidanceTwo;

    private void Update()
    {
        if (player.gameObject.GetComponent<UnlockAbility>().frogJumpUnlocked)
        {
            guidanceOne.SetActive(false);
            guidanceTwo.SetActive(true);
            
            Destroy(this);
        }
    }
}
