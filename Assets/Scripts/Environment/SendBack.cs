using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class SendBack : MonoBehaviour
{
    public Transform worldArea;
    public GameObject Player;
    public GameObject Page;

    private CameraChecker camerachecker;

    void Awake()
    {
        camerachecker = GameObject.FindObjectOfType<CameraChecker>();
    }

    void OnTriggerEnter()
    {
        camerachecker.is3D = true;
        //StartCoroutine(OpenLevel(SceneManager.GetActiveScene().buildIndex + 1));
        Debug.Log("Collided!");
        //Player.transform.position = worldArea.transform.position;                 
    }

    IEnumerator OpenLevel (int levelIndex)
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(levelIndex);
    }

}