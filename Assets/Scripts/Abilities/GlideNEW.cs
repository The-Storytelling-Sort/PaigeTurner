using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class GlideNEW : MonoBehaviour
{
    public bool isGliding;
    public float glideTimer;
    public float maxGlideTime = 8f;

    AudioManager audioManager;
    LanternNEW lantern;
    FrogJumpNEW frogJump;
    ChangeShape changeShape;
    ThirdPersonControllerNEW thirdPersonControllerNEW;
    InputManagerNEW inputManagerNEW;
    PauseMenu pauseMenu;

    public AbilityTimer abilityTimer;
    public GameObject abilityMeter;

    UnlockAbility unlockAbility;

    void Awake()
    {
        audioManager = GetComponent<AudioManager>();
        lantern = GetComponent<LanternNEW>();
        frogJump = GetComponent<FrogJumpNEW>();
        changeShape = GetComponent<ChangeShape>();
        thirdPersonControllerNEW = GetComponent<ThirdPersonControllerNEW>();
        inputManagerNEW = GetComponent<InputManagerNEW>();
        pauseMenu = GetComponent<PauseMenu>();
        unlockAbility = GetComponent<UnlockAbility>();
    }

    public void Update()
    {
   
        if (isGliding)
        {
            abilityMeter.SetActive(true);
            abilityTimer.SetMaxTime(maxGlideTime);
            glideTimer += Time.deltaTime;
            abilityTimer.SetTime(glideTimer);

            if (inputManagerNEW.look.x > 0)
                transform.eulerAngles += new Vector3(0, 0, -15);
            
            if (inputManagerNEW.look.x < 0)
                transform.eulerAngles += new Vector3(0, 0, 15);
        }

        if(!isGliding && !lantern.isLantern)
            abilityMeter.SetActive(false);
    
        if (glideTimer >= maxGlideTime || inputManagerNEW.glide && isGliding)
        {
            changeShape.glideModel.SetActive(false);
            changeShape.auriModel.SetActive(true);
            glideTimer = maxGlideTime;
            OffGlide();
        }
    }

    public void OnGlide()
    {
        if (unlockAbility.glideUnlocked)
        {
            if (!pauseMenu.isGamePaused && !pauseMenu.isInventory)
            {
                if (inputManagerNEW.glide && !isGliding)
                {
                    inputManagerNEW.glide = false;

                    if (!thirdPersonControllerNEW.grounded && glideTimer != maxGlideTime)
                    {
                        changeShape.GlideShape();
                        isGliding = true;
                        lantern.isLantern = false;
                        frogJump.isFrogJumping = false;
                        thirdPersonControllerNEW.doubleJump = false;
                        thirdPersonControllerNEW.jumpsRemaining = 0;
                        thirdPersonControllerNEW.gravity = 0f;
                        thirdPersonControllerNEW.verticalVelocity = 0f;
                        audioManager.IsTransforming();
                        audioManager.IsGliding();
                    }
                }
            }
        }
    }

    public void OffGlide()
    {
        inputManagerNEW.move = Vector2.zero;

        inputManagerNEW.glide = false;
        isGliding = false;
        audioManager.NotGliding();
        
        if (!lantern.isLantern)
            thirdPersonControllerNEW.gravity = -15;

        if (thirdPersonControllerNEW.grounded)
            glideTimer = 0;
    }
}
