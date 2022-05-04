using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    [SerializeField] private Animator elevatorDoor;


    void Start()
    {
        elevatorDoor.Play("A_Idle_Door_Elevator");    
    }
}
