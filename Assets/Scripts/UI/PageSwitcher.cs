using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PageSwitcher : MonoBehaviour
{
    public string frontText;
    public string backText;
    public PageSide pageSide;

    [SerializeField]
    GameObject displayUI;
    [SerializeField]
    Image pageDisplay;
    [SerializeField]
    TextMeshProUGUI pageText;

    // Start is called before the first frame update
    void OnEnable()
    {
        displayUI = transform.parent.GetChild(0).gameObject;
        pageDisplay = displayUI.transform.GetChild(0).GetComponent<Image>();
        pageText = pageDisplay.gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    void OnDisable()
    {
        pageSide = PageSide.pageFront;
        pageDisplay.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        pageText.gameObject.transform.localRotation = pageDisplay.gameObject.transform.localRotation;
    }

    public void SwapPage()
    {
        if (pageSide == PageSide.pageFront)
        {
            pageDisplay.gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
            pageText.gameObject.transform.localRotation = pageDisplay.gameObject.transform.localRotation;
            pageText.text = backText;
            pageSide = PageSide.pageBack;
            return;
        }
        
        if (pageSide == PageSide.pageBack)
        {
            pageDisplay.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            pageText.gameObject.transform.localRotation = pageDisplay.gameObject.transform.localRotation;
            pageText.text = frontText;
            pageSide = PageSide.pageFront;
            return;
        }
    }
}

public enum PageSide
{
    pageFront,
    pageBack
}