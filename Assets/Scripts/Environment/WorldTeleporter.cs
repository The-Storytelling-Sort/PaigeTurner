using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WorldTeleporter : MonoBehaviour
{
    public Transform worldArea;
    public GameObject Player;
    public GameObject Page;
    public GameObject PreviousPage;

    public AudioSource Narration;
    public AudioSource PrevNarration;

    private CameraChecker camerachecker;

    public float PageDeletionDelay;

    void Awake()
    {
        camerachecker = GameObject.FindObjectOfType<CameraChecker>();
        PageDeletionDelay = 1.25f;
    }

    void OnTriggerEnter()
    {
        Narration.Play();

        Page.GetComponent<Animator>().Play("PageFlipAnimation");
        camerachecker.flipped2to3 = true;
        //Invoke("DisablePage", PageDeletionDelay);

        if (PrevNarration.volume > 0)
        {
            PrevNarration.Stop();
        }
    }

    public void DisablePage()
    {
        PreviousPage.gameObject.SetActive(false);
    }

}