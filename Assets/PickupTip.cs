using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTip : MonoBehaviour
{
    [SerializeField] private GameObject[] pickups;
    [SerializeField] private int pickupNumber;
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private int noteCount;
    
    private DialogueManager dialogueManager;
    public bool pickedUp;

    private int compareAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickedUp = true;

            foreach (GameObject pickup in pickups)
            {
                if (pickup)
                {
                    compareAmount++;
                }

                else
                {
                    compareAmount--;
                }
            }

            if (compareAmount == noteCount)
            {
                dialogueManager = other.GetComponent<DialogueManager>();
                dialogueObject.isActive = true;

                    if (dialogueObject.type == textType.Narrative)
                        dialogueManager.GetDialogue(dialogueObject);
                    else if (dialogueObject.type == textType.Tip)
                        dialogueManager.DisplayTip(dialogueObject);
            }
        }
    }
}
