using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextLevel : MonoBehaviour
{
    [SerializeField] private Animator sceneTransition;
    [SerializeField] private int fadeTime;

    LevelLoader levelLoader;
    InputManagerNEW inputManagerNew;
    DialogueManager dialogueManager;
    InteractScript interact;

    void Awake()
    {
        levelLoader = GetComponent<LevelLoader>();
        inputManagerNew = GetComponent<InputManagerNEW>();
        dialogueManager = GetComponent<DialogueManager>();
        interact = GetComponent<InteractScript>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("LoadArchives") || other.CompareTag("LoadEastWing"))
        {
            //Debug.Log("Hold E or X to Interact");

            dialogueManager.tipText.text = "Hold the 'E' Key or 'X' Button to Interact";
            dialogueManager.tipText.enabled = true;
            interact.detectExit = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SceneTransitionInteract"))
        {
            dialogueManager.tipText.text = string.Empty;
            dialogueManager.tipText.enabled = false;
        }
    }

    IEnumerator SwitchSceneForward()
    {
        sceneTransition.Play("A_Transition_FadeOut");
        yield return new WaitForSeconds(fadeTime);

    }
    IEnumerator SwitchSceneBack()
    {
        sceneTransition.Play("A_Transition_FadeOut");
        yield return new WaitForSeconds(fadeTime);

    }
    IEnumerator SwitchSceneEast()
    {
        sceneTransition.Play("A_Transition_FadeOut");
        yield return new WaitForSeconds(fadeTime);

    }
    IEnumerator SwitchSceneArchives()
    {
        sceneTransition.Play("A_Transition_FadeOut");
        yield return new WaitForSeconds(fadeTime);

    }
}
