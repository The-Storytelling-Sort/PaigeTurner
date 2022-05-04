using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardCutscene : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject playerCam;
    [SerializeField] private GameObject rewardCam;
    [SerializeField] private GameObject rewardCam2;

    [SerializeField] private GameObject reward;
    [SerializeField] private GameObject reward2;

    [SerializeField] private GameObject poof;

    ThirdPersonControllerNEW controller;

    PageCollection pageCollector;


    void Start()
    {
        controller = player.GetComponent<ThirdPersonControllerNEW>();
        pageCollector = player.GetComponent<PageCollection>();
    }

    
    void Update()
    {
        if (pageCollector.pageCount == pageCollector.pageTotal)
        {
            StartCoroutine(RewardSequence());
            StartCoroutine(CamSwitch());
            playerCam.SetActive(false);
        }

        if (pageCollector.pageCount2 == pageCollector.pageTotal2)
        {
            StartCoroutine(RewardSequence2());
            StartCoroutine(CamSwitch2());
            playerCam.SetActive(false);
        }
    }

    IEnumerator RewardSequence()
    {
        rewardCam.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        reward.SetActive(true);
        poof.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        pageCollector.pageCount = 0;
        yield return new WaitForSeconds(0.0f);
        playerCam.SetActive(true);
    }

    IEnumerator CamSwitch()
    {
        yield return new WaitForSeconds(5.0f);
        rewardCam.SetActive(false);
    }

    IEnumerator RewardSequence2()
    {
        rewardCam2.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        poof.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        reward2.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        pageCollector.pageCount2 = 0;
        yield return new WaitForSeconds(0.0f);
        playerCam.SetActive(true);
    }

    IEnumerator CamSwitch2()
    {
        yield return new WaitForSeconds(5.2f);
        rewardCam2.SetActive(false);
    }
}
