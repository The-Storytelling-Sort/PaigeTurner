using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopeTurn : MonoBehaviour
{
    public GameObject telescopePivot;

    AudioSource audioSource;
    public AudioClip telescopeTurn;

    public BoxCollider boxCollider;

    private void Start()
    {
        telescopePivot.GetComponent<Animator>().enabled = false;

        audioSource = GetComponent<AudioSource>();

        boxCollider = GetComponent<BoxCollider>();
    }

    void OnTriggerEnter()
    {
        StartCoroutine(TelescopeCutscene());
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    IEnumerator TelescopeCutscene()
    {
        telescopePivot.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(4.5f);
        PlaySound(telescopeTurn);
        yield return new WaitForSeconds(3.0f);
        boxCollider.enabled = false;
    }
}
