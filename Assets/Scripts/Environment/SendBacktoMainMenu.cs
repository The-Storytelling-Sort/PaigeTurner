using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendBacktoMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OpenLevel(SceneManager.GetActiveScene().buildIndex - 3));
    }

    IEnumerator OpenLevel(int levelIndex)
    {
        yield return new WaitForSeconds(19.4f);
        SceneManager.LoadScene(levelIndex);
    }
}
