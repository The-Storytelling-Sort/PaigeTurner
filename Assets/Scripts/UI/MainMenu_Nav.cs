using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu_Nav : MonoBehaviour
{
    [Header("Animators")]
    
    public Animator storybook;
    public Animator mainmenuCamera;
    public Animator shiftCam;

    [Header("Canvases")]
    public GameObject mainMenuCanvas;
    public GameObject fakeMainMenu;
    public GameObject quitConfirmCanvas;
    public GameObject fakeQuitConfirm;

    [Header("Event Systems")]
    [SerializeField]
    private GameObject mainEvent;
    [SerializeField]
    private GameObject optionEvent;
    [SerializeField]
    private GameObject creditsEvent;
    [SerializeField]
    private GameObject quitEvent;

    [Header("Cameras")]
    [SerializeField]
    private GameObject storybookCam;
    [SerializeField]
    private GameObject optionsCam;
    [SerializeField]
    private GameObject creditsCam;

    public LevelLoader levelLoader;


    float eventTimer = 5.0f;
    bool pageFlip;

    float optionsTimer = 2.0f;
    bool optionsFlip = false;

    float backTimer = 2.0f;
    bool backFlip = false;

    float creditTimer = 2.0f;
    bool creditFlip = false;

    public TMP_Text resume1;
    public TMP_Text resume2;

    public Button resumeButton;

    void Start()
    {
        pageFlip = true;

        if (PlayerPrefs.GetString("Level") != "")
        {
            Debug.Log(PlayerPrefs.GetString("Level"));
            resumeButton.interactable = true;
            resumeButton.enabled = true;
            resume1.color = new Color(0, 0, 0, 1f);
            resume2.color = new Color(0, 0, 0, 1f);
        }
        else
        {
            Debug.Log(PlayerPrefs.GetString("Level"));
            resumeButton.interactable = false;
            resumeButton.enabled = false;
            resume1.color = new Color(0, 0, 0, 0.2f);
            resume2.color = new Color(0, 0, 0, 0.2f);
        }
    }

    void Update()
    {
        if (pageFlip)
        {
            eventTimer -= Time.deltaTime;
            if (eventTimer <= 0)
            {
                pageFlip = false;
                mainEvent.SetActive(true);
            }
        }
        if (optionsFlip)
        {
            optionsTimer -= Time.deltaTime;
            mainEvent.SetActive(false);
            optionEvent.SetActive(false);
            if (optionsTimer <= 0)
            {
                optionsFlip = false;
                optionEvent.SetActive(true);
                optionsTimer = 2.0f;
            }
        }
        if (backFlip)
        {
            backTimer -= Time.deltaTime;
            optionEvent.SetActive(false);
            creditsEvent.SetActive(false);
            if (backTimer <= 0)
            {
                backFlip = false;
                mainEvent.SetActive(true);
                backTimer = 2.0f;
            }
        }
        if (creditFlip)
        {
            creditTimer -= Time.deltaTime;
            mainEvent.SetActive(false);
            if (creditTimer <= 0)
            {
                creditsEvent.SetActive(true);
                creditTimer = 2.0f;
                creditFlip = false;
            }
        }
    }

    public void Resume()
    {
        if (PlayerPrefs.GetString("Level") != "")
        {
            levelLoader.LoadLevel(PlayerPrefs.GetString("Level"));
        }

    }
    
    public void StartGame()
    {
        mainEvent.SetActive(false);
        mainmenuCamera.Play("MainMenu_StartGame");
        storybook.Play("PageFlipForwards");
        StartCoroutine(GameStart());
    }

    public void Options()
    {
        optionsCam.SetActive(true);
        quitEvent.SetActive(false);
        fakeMainMenu.SetActive(false);
        optionsFlip = true;
    }

    public void Credits()
    {
        creditsCam.SetActive(true);
        mainEvent.SetActive(false);
        fakeMainMenu.SetActive(false);
        creditFlip = true;
    }

    public void BackCredits()
    {
        backFlip = true;
        creditsCam.SetActive(false);
        fakeMainMenu.SetActive(true);
    }

    public void BackOptions()
    {
        optionsCam.SetActive(false);
        fakeMainMenu.SetActive(true);
        backFlip = true;
    }

    public void Quit()
    {
        mainEvent.SetActive(false);
        quitEvent.SetActive(true);

        mainMenuCanvas.SetActive(false);
        fakeMainMenu.SetActive(false);
        quitConfirmCanvas.SetActive(true);
        fakeQuitConfirm.SetActive(true);
    }

    public void ConfirmYes()
    {
        quitEvent.SetActive(false);
        mainmenuCamera.Play("MainMenu_QuitGame");
        StartCoroutine(GameQuit());
    }

    public void ConfirmNo()
    {
        quitEvent.SetActive(false);
        mainEvent.SetActive(true);

        mainMenuCanvas.SetActive(true);
        fakeMainMenu.SetActive(true);
        quitConfirmCanvas.SetActive(false);
        fakeQuitConfirm.SetActive(false);
    }


    IEnumerator GameStart()
    {
        storybook.Play("PageFlipForwards");
        yield return new WaitForSeconds(3.66f);
        levelLoader.LoadLevel("Intro");
    }

    IEnumerator GameQuit()
    {
        storybook.Play("CloseBook");
        yield return new WaitForSeconds(2.5f);
        Application.Quit();
    }
}
