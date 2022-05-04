using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    DialogueObject dialogueObject;

    DialogueManager dialogueManager;

    void Awake()
    {
        if (dialogueObject != null)
        {
            dialogueObject.isActive = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogueManager = other.GetComponent<DialogueManager>();

            if (dialogueManager != null && !dialogueObject.isActive)
            {
                dialogueObject.isActive = true;

                if (dialogueObject.type == textType.Narrative)
                    dialogueManager.GetDialogue(dialogueObject);
                else if (dialogueObject.type == textType.Tip)
                    dialogueManager.DisplayTip(dialogueObject);
            }
        }
    }
}
