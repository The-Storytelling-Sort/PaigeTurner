using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource Running;
    public AudioSource Walking;
    public AudioSource Transform;
    public AudioSource Woosh;
    public AudioSource FrogJump;
    public AudioSource LanternOn;
    public AudioSource LanternOff;
    public AudioSource FireBallSound;
    [SerializeField] private float runVolume;
    [SerializeField] private float walkVolume;
    [SerializeField] private float wooshVolume;

    private void Awake()
    {
        Running.Play();
        Walking.Play();
        Woosh.Play();
        Running.volume = 0.0f;
        Walking.volume = 0.0f;
        Woosh.volume = 0.0f;
    }

    public void IsRunning()
    {
        Running.volume = runVolume;
    }

    public void NotRunning()
    {
        Running.volume = 0.0f;
    }

    public void IsGliding()
    {
        Woosh.volume = wooshVolume;
    }

    public void NotGliding()
    {
        Woosh.volume = 0.0f;
    }

    public void IsWalking()
    {
        Walking.volume = walkVolume;
    }
    
    public void NotWalking()
    {
        Walking.volume = 0.0f;
    }

    public void IsTransforming()
    {
        Transform.Play();
    }

    public void IsFrog()
    {
        FrogJump.Play();
    }

    public void LanternIsOn()
    {
        LanternOn.Play();
    }

    public void LanternIsOff()
    {
        LanternOff.Play();
    }

    public void FireBall()
    {
        FireBallSound.Play();
    }
}
