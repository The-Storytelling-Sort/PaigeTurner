using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float clipTime;
    [SerializeField] private bool isIntro;
    public LevelLoader levelLoader;
    void Start()
    {
        StartCoroutine(OpenLevel());
    }

    IEnumerator OpenLevel()
    {
        yield return new WaitForSeconds(clipTime);
        if (isIntro)
        {
            levelLoader.LoadLevel("TurnersOffice");
        }

        else
        {
            levelLoader.LoadLevel("Archives");
        }
    }
}
