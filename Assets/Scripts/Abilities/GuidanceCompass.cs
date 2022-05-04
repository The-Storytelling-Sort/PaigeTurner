using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine;

public class GuidanceCompass : MonoBehaviour
{
    [SerializeField] GameObject Compass;
    [SerializeField] GameObject CandleGuidanceObject;
    [SerializeField] CandleGuidance candleGuidanceScript;
    DialogueManager dialogueManager;
    [SerializeField]
    GameObject tipHolder;
    [SerializeField]
    TextMeshProUGUI promptText;
    [SerializeField]
    string tipBoxPrompt;
    
    

    private void Start()
    {
        Compass.gameObject.SetActive(false);
        dialogueManager = GetComponent<DialogueManager>();
        tipHolder = dialogueManager.tipHolder;
        promptText = dialogueManager.tipText;
        CandleGuidanceObject = GameObject.FindGameObjectWithTag("CandleGuidanceObject");
        candleGuidanceScript = CandleGuidanceObject.GetComponent<CandleGuidance>();

    }

    private void Update()
    {
        if (candleGuidanceScript.lightArea.transform != null && Compass != null)
        {
            Compass.transform.LookAt(candleGuidanceScript.lightArea.transform.position);
        }
        
    }
    [ContextMenu("TurnOnGuidance")]
    public void TurnOnGuidance()
    {
        if(CandleGuidanceObject != null && candleGuidanceScript != null)
        {
            Compass.gameObject.SetActive(true);
            StartCoroutine(TurnOff());
        }
        else
        {
            tipHolder.SetActive(true);
            promptText.text = tipBoxPrompt;
            StartCoroutine(dialogueManager.TipTimer());
        }
    }
    IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(7);
        Compass.gameObject.SetActive(false);
        StopCoroutine(TurnOff());
    }
    void OnCompass()
    {
        TurnOnGuidance();
        Debug.Log("Compass");
    }
}
