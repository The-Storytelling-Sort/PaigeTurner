using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

// Imari - This class is attached to the inventory buttons in the UI in order to display the contents of a note
public class InventoryControl : MonoBehaviour, ISelectHandler, IPointerEnterHandler // Required interface when using OnSelect method
{
    public NoteScriptableObject noteObject;

    [SerializeField]
    GameObject inventoryMenu, displayUI;

    [SerializeField]
    CloseButton closeButton;

    [SerializeField]
    PageSwitcher pageSwitcher;

    [SerializeField]
    Image pageDisplay, tutorialDisplay;

    [SerializeField]
    TextMeshProUGUI nameText, buttonText, pageText, tutorialText, tutorialTitle;

    [SerializeField]
    VideoPlayer videoPlayer;

    TutorialPage tutorial;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Init()
    {
        inventoryMenu = transform.parent.parent.gameObject;
        nameText = inventoryMenu.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
        
        displayUI = inventoryMenu.transform.parent.GetChild(0).gameObject;
        closeButton = inventoryMenu.transform.parent.GetChild(2).GetComponent<CloseButton>();
        pageSwitcher = inventoryMenu.transform.parent.GetChild(3).GetComponent<PageSwitcher>();

        pageDisplay = displayUI.transform.GetChild(0).GetComponent<Image>();
        pageText = pageDisplay.gameObject.GetComponentInChildren<TextMeshProUGUI>();

        tutorialDisplay = displayUI.transform.GetChild(1).GetComponent<Image>();
        tutorialTitle = tutorialDisplay.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        tutorialText = tutorialDisplay.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        videoPlayer = tutorialDisplay.gameObject.GetComponent<VideoPlayer>();
        videoPlayer.isLooping = true;
        
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = "---";
        buttonText.fontStyle = FontStyles.Italic;

        if (noteObject is TutorialPage)
        {
            tutorial = (TutorialPage)noteObject;
        }
    }

    public void ViewDocument()
    {
        if (noteObject != null && noteObject.inInventory)
        {
            inventoryMenu.SetActive(false);
            displayUI.SetActive(true);
            closeButton.returnState = ReturnState.fromMenu;

            if (noteObject is TutorialPage)
            {   
                tutorialDisplay.gameObject.SetActive(true);
                pageDisplay.gameObject.SetActive(false);

                tutorialDisplay.sprite = noteObject.noteDisplay;
                tutorialTitle.text = tutorial.displayTitle;
                tutorialText.text = tutorial.displayText;
                videoPlayer.clip = tutorial.displayClip;
                videoPlayer.Play();

                closeButton.inTutorial = true;
                closeButton.singlePage = true;
                closeButton.GetComponent<Button>().Select();
                return;
            }
            else
            {
                pageDisplay.gameObject.SetActive(true);
                tutorialDisplay.gameObject.SetActive(false);

                pageDisplay.sprite = noteObject.noteDisplay;
                pageText.text = noteObject.frontPageText;
                closeButton.inTutorial = false;

                if (noteObject.multiPage)
                {
                    closeButton.singlePage = false;
                    pageSwitcher.gameObject.SetActive(true);
                    pageSwitcher.frontText = noteObject.frontPageText;
                    pageSwitcher.backText = noteObject.backPageText;
                    pageSwitcher.GetComponent<Button>().Select();
                }
                else
                {
                    closeButton.singlePage = true;
                    closeButton.GetComponent<Button>().Select();
                }
                return;
            }
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (noteObject != null && noteObject.inInventory)
        {
            nameText.text = noteObject.noteName;
            nameText.fontStyle = FontStyles.Normal;
        }
        else
        {
            nameText.text = "Not Found";
            nameText.fontStyle = FontStyles.Italic;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.gameObject.GetComponent<Button>().Select();
    }

    void Update()
    {
        if (noteObject != null && noteObject.inInventory)
        {
            buttonText.text = noteObject.menuName;
            buttonText.fontStyle = FontStyles.Normal;
            buttonText.fontStyle = FontStyles.SmallCaps;
        }
    }
}
