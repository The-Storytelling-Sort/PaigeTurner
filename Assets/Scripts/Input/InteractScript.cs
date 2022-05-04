using UnityEngine;

public class InteractScript : MonoBehaviour
{
    // Check if climbable object is nearby
    public bool detectClimb;
    public bool detectExit;
    [HideInInspector]
    public string level_name;
    //public bool detectDialogue;

    ThirdPersonControllerNEW thirdPersonController;
    InputManagerNEW inputManager;
    ClimbNEW climbNEW;
    DialogueManager dialogueManager;
    LevelLoader levelLoader;

    void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonControllerNEW>();
        inputManager = GetComponent<InputManagerNEW>();
        climbNEW = GetComponent<ClimbNEW>();
        dialogueManager = GetComponent<DialogueManager>();
        levelLoader = GetComponent<LevelLoader>();
    }

    public void OnInteract()
    {
        //Debug.Log("Interacting...");
        if (detectExit)
        {
            detectExit = false;
            levelLoader.LoadLevel(level_name);
        }

        if (detectClimb)
        {
            if (!climbNEW.isClimbing)
            {
                climbNEW.isClimbing = true;
            }
            else
            {
                climbNEW.isClimbing = false;
            }
        }
        else
        {
            //Debug.Log("Nothing happened?");
            return;
        }
    }
}
