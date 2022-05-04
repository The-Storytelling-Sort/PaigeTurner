using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageTurnerStreaming : MonoBehaviour
{
    public GameObject ArchiveDrama;

    void Start()
    {
        SceneManager.LoadSceneAsync("Archives", LoadSceneMode.Additive);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Archives&Drama")
        {
            ArchvieDrama();
            StartCoroutine(DisableTrigger());
        }
    }

    public void ArchvieDrama()
    {
        if (GameObject.Find("--ARCHIVES--"))
        {
            SceneManager.UnloadSceneAsync("Archives", UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        }
        else
        {
            SceneManager.LoadSceneAsync("Archives", LoadSceneMode.Additive);
        }

        if (GameObject.Find("--DRAMA_PROPS--"))
        {
            SceneManager.UnloadSceneAsync("Drama", UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        }
        else
        {
            SceneManager.LoadSceneAsync("Drama", LoadSceneMode.Additive);
        }
    }

    public IEnumerator DisableTrigger()
    {
        ArchiveDrama.SetActive(false);
        yield return new WaitForSeconds(5);
        ArchiveDrama.SetActive(true);
    }
}