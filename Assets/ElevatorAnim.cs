using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorAnim : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.Play("ElevatorMoveUp");
        }
    }
}
