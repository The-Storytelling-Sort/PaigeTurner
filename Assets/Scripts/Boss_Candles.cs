using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Candles : MonoBehaviour
{

    public GameObject finalTrigger;
    public float waitTimer;
    public Light candle1;
    public Light candle2;
    public Light candle3;
    private bool end;
    public ToNextLevel toNextLevel;
    
    [SerializeField] private Animator sceneTransition;
    [SerializeField] private int fadeTime;
    [SerializeField] private GameObject bossFight;
    [SerializeField] private GameObject finalCam;
    [SerializeField] private GameObject playerCam;
    [SerializeField] private GameObject turnerVFX;
    [SerializeField] private GameObject killzones;
    [SerializeField] private GameObject reticle;
    [SerializeField] private GameObject music;


    [SerializeField] private Animator turnerAnimator;


    public LevelLoader levelLoader;

    void Update()
    {
        if(candle1.enabled && candle2.enabled && candle3.enabled)
        {
            if (end == false)
            {
                StartCoroutine(Ending());
                end = true;
            }
        }
    }

    IEnumerator Ending()
    {
        if (reticle)
        {
            reticle.SetActive(false);
        }
        
        killzones.SetActive(false);
        playerCam.SetActive(false);
        finalCam.SetActive(true);
        turnerAnimator.Play("Defeat");
        turnerVFX.SetActive(false);
        bossFight.SetActive(false);
        finalTrigger.SetActive(true);
        yield return new WaitForSeconds(waitTimer);
        sceneTransition.Play("A_Transition_FadeOut");
        yield return new WaitForSeconds(2.0f);
        Debug.Log("DoneWithGame");
        levelLoader.LoadLevel("Credits");
    }
    
    IEnumerator SwitchSceneForward()
    {
        sceneTransition.Play("A_Transition_FadeOut");
        yield return new WaitForSeconds(fadeTime);

    }
[ContextMenu("End Game")]
    void EndGame()
    {
        StartCoroutine(Ending());
        StartCoroutine(StopMusic());
    }

    public IEnumerator StopMusic()
    {
        float totalTime = 5f;
        float currentTime = 0f;

        while (music.gameObject.GetComponent<AudioSource>().volume > 0)
        {
            currentTime += Time.deltaTime;
            music.gameObject.GetComponent<AudioSource>().volume = Mathf.Lerp(0.25f, 0f, currentTime / fadeTime);
            yield return null;  
        }
    }
}
