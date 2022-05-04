using UnityEngine;

public class FrogJumpNEW : MonoBehaviour
{
    public bool frogJumpUnlocked;
    public bool isFrogJumping;
    public float frogJumpHeight = 6f;

    ThirdPersonControllerNEW thirdPersonControllerNEW;
    ChangeShape changeShape;
    AudioManager audioManager;
    PauseMenu pauseMenu;
    UnlockAbility unlockAbility;
    
    void Awake()
    {
        changeShape = GetComponent<ChangeShape>();
        audioManager = GetComponent<AudioManager>();
        thirdPersonControllerNEW = GetComponent<ThirdPersonControllerNEW>();
        pauseMenu = GetComponent<PauseMenu>();
        unlockAbility = GetComponent<UnlockAbility>();

    }
    
    public void OnFrogJump()
    {
        if (unlockAbility.frogJumpUnlocked)
        {
            if (!pauseMenu.isGamePaused && !pauseMenu.isInventory)
            {
                changeShape.FrogShape();

                audioManager.IsTransforming();
                audioManager.IsFrog();

                isFrogJumping = true;

                thirdPersonControllerNEW.verticalVelocity = Mathf.Sqrt(frogJumpHeight * -2f * thirdPersonControllerNEW.gravity);

                thirdPersonControllerNEW.jumpsRemaining--;

                if (thirdPersonControllerNEW.jumpsRemaining <= 0)
                    thirdPersonControllerNEW.jumpsRemaining = 0;
            }
        }
    }
}
