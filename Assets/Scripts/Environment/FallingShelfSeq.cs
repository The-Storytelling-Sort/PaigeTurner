using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FallingShelfSeq : MonoBehaviour
{
    public GameObject pushProp;
    public GameObject otherTrigger;

    public AudioSource audioSource;

    public AudioClip creakSound;
    public AudioClip slamSound;

    public float amplitude;
    public float frequency;
    public float duration;
    public CinemachineFreeLook cm;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pushProp.SetActive(true);
            Destroy(otherTrigger, 2);
            Destroy(pushProp, 5);
            GetComponent<Collider>().enabled = false;
            StartCoroutine(FallingShelf());
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    IEnumerator FallingShelf()
    {
        PlaySound(creakSound);
        yield return new WaitForSeconds(6f);
        PlaySound(slamSound);
        yield return new WaitForSeconds(0.125f);
        ShakeItBaby();
    }

    public void ShakeItBaby()
    {
        StartCoroutine(Shake());
    }

    //camera shake
    public IEnumerator Shake()
    {
        Noise(amplitude, frequency);
        yield return new WaitForSeconds(duration);
        Noise(0,0);
    }

    public void Noise(float amplitude,float frequency)
    {
        cm.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
        cm.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
        cm.GetRig(2).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
        cm.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequency;
        cm.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequency;
        cm.GetRig(2).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequency;
    }



}
