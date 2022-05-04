using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public int creditsTime;

    void Start()
    {
        StartCoroutine(CreditsSequence());
    }

    IEnumerator CreditsSequence()
    {
        yield return new WaitForSeconds(creditsTime);
        SceneManager.LoadScene("MainMenu");
    }
}
