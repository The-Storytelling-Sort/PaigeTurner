 using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public TMP_Text progressText;

    DialogueManager dialogueManager;
    [SerializeField]
    GameObject tipHolder;
    [SerializeField]
    TextMeshProUGUI promptText;

    InteractScript interaction;

    void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
        //tipHolder = dialogueManager.tipHolder;
        //promptText = dialogueManager.tipText;

        interaction = GetComponent<InteractScript>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Opens the tip box with the prompt text
        if (interaction != null && (other.CompareTag("LoadArchives") || other.CompareTag("LoadEastWing") || 
            other.CompareTag("LoadWestWing") || other.CompareTag("LoadDestroyedArchives")))
        {
            tipHolder.SetActive(true);
            promptText.text = "Hold the 'E' Key or 'X' Button to Progress";
            interaction.detectExit = true;
        }

        // Sends the level name to the interact script to call LoadLevel after input
        if (other.CompareTag("LoadArchives"))
        {
            interaction.level_name = "Archives";
            //LoadLevel("Archives");
        }
        
        if (other.CompareTag("LoadEastWing"))
        {
            interaction.level_name = "EastWing";
            //LoadLevel("EastWing");
        }
        
        if (other.CompareTag("LoadWestWing"))
        {
            interaction.level_name = "WestWing";
            //LoadLevel("WestWing");
        }
        
        if (other.CompareTag("LoadDestroyedArchives"))
        {
            interaction.level_name = "destroyed_Archives";
            //LoadLevel("destroyed_Archives");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Closes the tip box and disables interaction
        if (interaction != null && (other.CompareTag("LoadArchives") || other.CompareTag("LoadEastWing") ||
            other.CompareTag("LoadWestWing") || other.CompareTag("LoadDestroyedArchives")))
        {
            tipHolder.SetActive(false);
            promptText.text = string.Empty;
            interaction.level_name = string.Empty;
            interaction.detectExit = false;
        }
    }

    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadAsynchronously(levelName));
    }

    IEnumerator LoadAsynchronously(string levelName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);
        
        loadingScreen.SetActive(true);
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }
    
}
