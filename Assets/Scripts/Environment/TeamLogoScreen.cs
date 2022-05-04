using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamLogoScreen : MonoBehaviour
{
    [SerializeField] private float splashTime;
    void Start()
    {
        StartCoroutine(SplashScreen());
    }

    IEnumerator SplashScreen()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(splashTime);
        Time.timeScale = 1;
    }
}
