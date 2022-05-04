using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class CloseButton : MonoBehaviour, ISelectHandler, IPointerEnterHandler // Required interface when using OnSelect method
{
    [SerializeField]
    GameObject inventoryMenu, displayUI;
    
    [SerializeField]
    Image pageDisplay, tutorialDisplay;
    
    [SerializeField]
    TextMeshProUGUI pageText, nameText, tutorialText, tutorialTitle;

    [SerializeField]
    VideoPlayer videoPlayer;

    public PauseMenu pauseMenu;
    
    Button returnButton;
    public bool singlePage, inTutorial;

    public PageSwitcher pageSwitcher;

    public ReturnState returnState;
    
    void Awake()
    {
        displayUI = transform.parent.GetChild(0).gameObject;
        inventoryMenu = transform.parent.GetChild(1).gameObject;
        pageSwitcher = transform.parent.GetChild(3).GetComponent<PageSwitcher>();

        nameText = inventoryMenu.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
        pageDisplay = displayUI.transform.GetChild(0).GetComponent<Image>();
        pageText = pageDisplay.gameObject.GetComponentInChildren<TextMeshProUGUI>();

        tutorialDisplay = displayUI.transform.GetChild(1).GetComponent<Image>();
        tutorialTitle = tutorialDisplay.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        tutorialText = tutorialDisplay.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        videoPlayer = tutorialDisplay.gameObject.GetComponent<VideoPlayer>();

        returnButton = GetComponent<Button>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (nameText.enabled)
        {
            nameText.text = "-Close-";
            nameText.fontStyle = FontStyles.Bold;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        returnButton.Select();
    }

    public void CloseMenu()
    {
        pageText.text = string.Empty;
        tutorialTitle.text = string.Empty;
        tutorialText.text = string.Empty;

        pageDisplay.gameObject.SetActive(false);
        tutorialDisplay.gameObject.SetActive(false);
        
        displayUI.SetActive(false);
        inventoryMenu.SetActive(true);

        if (inTutorial)
        {
            videoPlayer.Stop();
        }

        if (returnState == ReturnState.fromGame)
        {
            pauseMenu.InventoryOff();
            return;
        }

        if (returnState == ReturnState.fromMenu)
        {
            if (!singlePage)
            {
                pageSwitcher.gameObject.SetActive(false);
            }

            returnState = ReturnState.fromGame;
            returnButton.Select();
            return;
        }
    }
}

public enum ReturnState
{
    fromMenu,
    fromGame
}