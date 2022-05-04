using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NorthWingPageTracker : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip HalfWayClip;

    public AudioClip twoLeftClip;

    public AudioClip oneLeftClip;

    public AudioClip noneLeftClip;

    [SerializeField]
    private GameObject BookCutsceneTrigger;

    private int oldNumber;
    
    DialogueManager dialogueManager;

    [SerializeField] private GameObject storybook;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject oldBook;
    
    [SerializeField] private DialogueObject halfway;
    [SerializeField] private DialogueObject twoLeft;
    [SerializeField] private DialogueObject oneLeft;
    [SerializeField] private DialogueObject noneLeft;



    void Start()
    {
        oldNumber = NoteHolder.pagesColleted;
        audioSource = GetComponent<AudioSource>();
        dialogueManager = player.GetComponent<DialogueManager>();
    }

    void Update()
    {
       if(NoteHolder.pagesColleted != oldNumber)
        {
            oldNumber = NoteHolder.pagesColleted;
            PageCheckVoice();
        }
    }
[ContextMenu("Christian Mode")]
    void ChristianCheat()
    {
        NoteHolder.pagesColleted = 6;
    }

    void PageCheckVoice()
    {
        switch (NoteHolder.pagesColleted)
        {
            case int when (NoteHolder.pagesColleted == 3):
                PlaySound(HalfWayClip);
                halfway.isActive = true;
                dialogueManager.GetDialogue(halfway);
                break;

            case int when (NoteHolder.pagesColleted == 4):
                PlaySound(twoLeftClip);
                twoLeft.isActive = true;
                dialogueManager.GetDialogue(twoLeft);
                break;

            case int when (NoteHolder.pagesColleted == 5):
                PlaySound(oneLeftClip);
                oneLeft.isActive = true;
                dialogueManager.GetDialogue(oneLeft);
                break;

            case int when (NoteHolder.pagesColleted == 6):
                PlaySound(noneLeftClip);
                storybook.SetActive(true);
                noneLeft.isActive = true;
                dialogueManager.GetDialogue(noneLeft);
                BookCutsceneTrigger.SetActive(false);
                oldBook.SetActive(false);
                break;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
