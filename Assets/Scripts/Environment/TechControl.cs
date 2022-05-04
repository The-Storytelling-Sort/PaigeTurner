using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Cinemachine;

public class TechControl : MonoBehaviour
{
    [Header("Audio Mixers")]
    public AudioMixer soundMixer;
    public AudioMixer musicMixer;

    void Awake()
    {
        if (Debug.unityLogger != null) 
            Debug.unityLogger.logEnabled = false;
    }

    void Start()
    {
        SetScreenMode(true);
    }
    
    //audio control
    public void SetSoundLevel (float sliderValue)
    {
        soundMixer.SetFloat("SoundVol", Mathf.Log10 (sliderValue) * 20);
    }

    public void SetMusicLevel (float sliderValue)
    {
        musicMixer.SetFloat("MusicVol", Mathf.Log10 (sliderValue) * 10);
    }

    //fullscreen toggle
    public void SetScreenMode(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
