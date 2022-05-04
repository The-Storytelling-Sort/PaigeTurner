using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class PauseMenu : MonoBehaviour
{
    public bool isGamePaused = false;
    public bool isInventory;
    public GameObject pauseMenuUI;
    Button pauseButton;

    public float timeScale;
    
    InputManagerNEW inputManager;
    PlayerInput playerInput;
    
    // Imari - Added this for inventory menu UI
    public GameObject inventoryListUI;
    CloseButton closeButton;
    VideoPlayer videoPlayer;
    GameObject inventoryMenu, displayUI;
    Image pageDisplay, tutorialDisplay;
    TextMeshProUGUI tutorialText, tutorialTitle;
    PageSwitcher pageSwitcher;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        inputManager = GetComponent<InputManagerNEW>();

        closeButton = inventoryListUI.GetComponentInChildren<CloseButton>();
        closeButton.pauseMenu = this;
        inventoryMenu = inventoryListUI.transform.GetChild(1).gameObject;
        pageSwitcher = inventoryListUI.transform.GetChild(3).GetComponent<PageSwitcher>();
        
        displayUI = inventoryListUI.transform.GetChild(0).gameObject;
        pageDisplay = displayUI.transform.GetChild(0).GetComponent<Image>();
        tutorialDisplay = displayUI.transform.GetChild(1).GetComponent<Image>();
        tutorialTitle = tutorialDisplay.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        tutorialText = tutorialDisplay.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        videoPlayer = tutorialDisplay.gameObject.GetComponent<VideoPlayer>();

        pauseButton = pauseMenuUI.transform.GetChild(1).GetChild(0).GetComponent<Button>();
        
        timeScale = 1;
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;
    }

    public void OnPause()
    {
        if (inputManager.pause && !isGamePaused && !isInventory)
        {
            PauseOn();
        }
        
        if (inputManager.pause && isGamePaused)
        {
            PauseOff();
        }
    }

    public void PauseOn()
    {
        inputManager.pause = false;
        pauseMenuUI.SetActive(true);
        timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        isGamePaused = true;
        pauseButton.Select();
    }
    
    public void PauseOff()
    {
        pauseMenuUI.SetActive(false);
        timeScale = 1;
        isGamePaused = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnInventory()
    {
        if (inputManager.inventory && !isInventory && !isGamePaused)
        {
            InventoryOn();
        }

        if (inputManager.inventory && isInventory)
        {
            InventoryOff();
        }
    }
   
    public void InventoryOn()
    {
        inputManager.inventory = false;
        inventoryListUI.SetActive(true);
        timeScale = 0f;
        isInventory = true;
        Cursor.lockState = CursorLockMode.None;
        closeButton.returnState = ReturnState.fromGame;
        closeButton.gameObject.GetComponent<Button>().Select();
    }
    
    public void InventoryOff()
    {
        inventoryListUI.SetActive(false);
        pageSwitcher.gameObject.SetActive(false);
        pageDisplay.gameObject.SetActive(false);
        tutorialDisplay.gameObject.SetActive(false);
        displayUI.SetActive(false);
        inventoryMenu.SetActive(true);

        timeScale = 1f;
        isInventory = false;
        Cursor.lockState = CursorLockMode.Locked;    
    }

    public void TutorialTrigger(TutorialPage tutorial)
    {
        inventoryListUI.SetActive(true);
        timeScale = 0f;
        isInventory = true;
        Cursor.lockState = CursorLockMode.None;

        closeButton.inTutorial = true;
        closeButton.singlePage = true;
        closeButton.returnState = ReturnState.fromGame;
        closeButton.gameObject.GetComponent<Button>().Select();

        inventoryMenu.SetActive(false);
        displayUI.SetActive(true);
        tutorialDisplay.gameObject.SetActive(true);
        pageDisplay.gameObject.SetActive(false);

        tutorialDisplay.sprite = tutorial.noteDisplay;
        tutorialTitle.text = tutorial.displayTitle;
        tutorialText.text = tutorial.displayText;
        videoPlayer.clip = tutorial.displayClip;
        videoPlayer.isLooping = true;
        videoPlayer.Play();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        inventoryListUI.SetActive(false);
        timeScale = 1f;
        isGamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Restart()
    {
        pauseMenuUI.SetActive(false);
        timeScale = 1f;
        isGamePaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Debug.Log("Quitting!");
        //Application.Quit();
        timeScale = 1;
        SceneManager.LoadScene(sceneBuildIndex:0);

    }

    public void BugReport()
    {
        playerInput.actions.Disable();
    }
    
    public void ExitBugReport()
    {
        playerInput.actions.Enable();
    }
    
}
