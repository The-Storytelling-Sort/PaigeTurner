using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this script to the ability collectibles to display the tutorial pages on pickup
public class TutorialTrigger : MonoBehaviour
{
    public TutorialPage tutorialObject;
    [SerializeField]
    BoxCollider boxCollider;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();

#if UNITY_EDITOR
        // This should only run in the Unity Editor, sets the notes to false hopefully
        tutorialObject.inInventory = false;
#endif
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PauseMenu pauseMenu = other.GetComponent<PauseMenu>();

            boxCollider.enabled = false;
            tutorialObject.inInventory = true;
            pauseMenu.TutorialTrigger(tutorialObject);
        }
    }
}
