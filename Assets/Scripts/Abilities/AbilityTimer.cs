using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AbilityTimer : MonoBehaviour
{
    public Slider slider;
    public GlideNEW glideAbility;
    public LanternNEW lanternAbility;

    
    public void SetMaxTime(float time)
    {
        slider.maxValue = time;
        
        if(glideAbility.isGliding)
            slider.value = glideAbility.glideTimer;
        
        if(lanternAbility.isLantern)
            slider.value = lanternAbility.currentTime;

    }
    public void SetTime(float time)
    {
        slider.value = time;
    }
}
