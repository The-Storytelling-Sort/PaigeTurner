using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTimer : MonoBehaviour
{
    [SerializeField] private float sceneTime;
    [SerializeField] private GameObject sceneImage;
    void Start()
    {
        StartCoroutine(DisableCutscene());
    }

    public IEnumerator DisableCutscene()
    {
        yield return new WaitForSeconds(sceneTime);
        sceneImage.SetActive(false);
    }

}
