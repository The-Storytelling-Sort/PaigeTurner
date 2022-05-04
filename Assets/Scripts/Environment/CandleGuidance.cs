using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CandleGuidance : MonoBehaviour
{
    [SerializeField] private GameObject[] lights;
    [SerializeField] public GameObject lightArea;
    [SerializeField] private int candleNumber;
    

    void Awake()
    {
        candleNumber = 0;

        if (PlayerPrefs.GetInt("NorthWing") == 1 && SceneManager.GetActiveScene().name == "Archives")
        {
            candleNumber = 6;
        }
        
    }

    void Start()
    {
        LightCandle();
    }

    void LightCandle()
    {
        lights[candleNumber].SetActive(true);
    }

    void ExtinguishCandle()
    {
        lights[candleNumber].SetActive(false);
    }

    void NextCandle()
    {
        candleNumber++;
    }

    void MoveArea()
    {
        lightArea.transform.position = lights[candleNumber].transform.position;
    }

    void OnTriggerEnter()
    {
        ExtinguishCandle();
        NextCandle();
        MoveArea();
        LightCandle();

    }
}
