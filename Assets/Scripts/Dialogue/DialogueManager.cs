using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    GameObject dialogueUI;
    [SerializeField]
    GameObject dialogueHolder;
    [SerializeField]
    TextMeshProUGUI dialogueText;
    [SerializeField]
    Image dialogueImage;
    [SerializeField]
    AudioSource dialogueAudiosource;

    public GameObject tipHolder;
    public TextMeshProUGUI tipText;

    DialogueObject currentDialogue;

    int index;
    public bool inDialogue;
    [SerializeField]
    float tipTimer = 5f;
    float textTimer;

    bool isVisible = true;

    void Awake()
    {
        dialogueUI.SetActive(true);
        dialogueHolder = dialogueUI.transform.GetChild(1).gameObject;
        dialogueText = dialogueHolder.GetComponentInChildren<TextMeshProUGUI>();
        dialogueImage = dialogueHolder.transform.GetChild(0).GetComponent<Image>();
        dialogueAudiosource = dialogueUI.GetComponentInChildren<AudioSource>();

        tipHolder = dialogueUI.transform.GetChild(2).gameObject;
        tipText = tipHolder.GetComponentInChildren<TextMeshProUGUI>();

        inDialogue = false;

        dialogueText.text = string.Empty;
        dialogueHolder.SetActive(false);

        tipText.text = string.Empty;
        tipHolder.SetActive(false);
    }

    public void GetDialogue(DialogueObject dialogue)
    {
        inDialogue = true;
        
        index = 0;
        currentDialogue = dialogue;

        dialogueHolder.SetActive(isVisible);

        DisplayDialogue();
    }

    public void DisplayDialogue()
    {
        if (currentDialogue != null)
        {
            dialogueText.text = $"{currentDialogue.dialogueInfo[index].characterName}:\n{currentDialogue.dialogueInfo[index].dialogueText}";
            dialogueAudiosource.PlayOneShot(currentDialogue.dialogueInfo[index].audioClip);
            

            if (currentDialogue.dialogueInfo[index].characterImage != null)
            {
                dialogueImage.sprite = currentDialogue.dialogueInfo[index].characterImage;
            }

            if (currentDialogue.dialogueInfo[index].textTimer <= 0f)
            {
                textTimer = 5f;
            }
            else
            {
                textTimer = currentDialogue.dialogueInfo[index].textTimer;
            }

            StartCoroutine(DialogueTimer());
        }
    }

    IEnumerator DialogueTimer()
    {
        yield return new WaitForSeconds(textTimer);
        NextDialogue();
    }

    public void NextDialogue()
    {
        if (index < currentDialogue.dialogueInfo.Length - 1)
        {
            index++;
            DisplayDialogue();
        }
        else
        {
            dialogueText.text = string.Empty;
            dialogueHolder.SetActive(false);
            inDialogue = false;
        }
    }

    public void DisplayTip(DialogueObject dialogue)
    {
        tipHolder.SetActive(true);
        tipText.text = dialogue.dialogueInfo[0].dialogueText;
        StartCoroutine(TipTimer());
    }

    public IEnumerator TipTimer()
    {
        yield return new WaitForSeconds(tipTimer);
        CloseTip();
    }

    public void CloseTip()
    {
        tipText.text = string.Empty;
        tipHolder.SetActive(false);
    }

    public void SubtitleToggle(bool newValue)
    {
        isVisible = newValue;
    }
}
