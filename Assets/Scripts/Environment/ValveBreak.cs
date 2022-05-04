using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveBreak : MonoBehaviour
{
    public Rigidbody rb;

    public Animator failedValve;
    public GameObject waterLeak;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip valveSound;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(FailedValve());
            GetComponent<Collider>().enabled = false;
            PlaySound(valveSound);
        }
    }

    IEnumerator FailedValve()
    {
        failedValve.Play("A_Valve_Turn");
        yield return new WaitForSeconds(1.25f);
        rb.isKinematic = false;
        yield return new WaitForSeconds(1.5f);
        waterLeak.SetActive(true);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
