using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostCredits : MonoBehaviour
{
    [SerializeField] private GameObject video;
    [SerializeField] private GameObject image;
    [SerializeField] private GameObject music;
    [SerializeField] private float waitTime;
    void Start()
    {
        StartCoroutine(StopMusic());
        StartCoroutine(SpawnVideo());
    }

    public IEnumerator StopMusic()
    {
        yield return new WaitForSeconds(waitTime);
        float totalTime = 3f;
        float currentTime = 0f;
        float currentVolume = music.gameObject.GetComponent<AudioSource>().volume;

        while (music.gameObject.GetComponent<AudioSource>().volume > 0)
        {
            currentTime += Time.deltaTime;
            music.gameObject.GetComponent<AudioSource>().volume = Mathf.Lerp(currentVolume, 0f, currentTime / totalTime);
            yield return null;  
        }
    }

    public IEnumerator SpawnVideo()
    {
        yield return new WaitForSeconds(waitTime);
        image.SetActive(true);
        video.SetActive(true);
    }
}
