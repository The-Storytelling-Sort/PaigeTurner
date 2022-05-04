using UnityEngine;

public class ChangeShape : MonoBehaviour
{
    GlideNEW glide;
    FrogJumpNEW frogJump;
    LanternNEW lantern;
    FlattenNEW flatten;
    ThirdPersonControllerNEW thirdPersonControllerNEW;
    private PauseMenu pauseMenu;

    [HideInInspector]
    public CharacterController characterController;

    public GameObject auriModel;
    public GameObject glideModel;
    public GameObject frogModel;
    public GameObject lanternModel;

    void Awake()
    {
        glide = GetComponent<GlideNEW>();
        frogJump = GetComponent<FrogJumpNEW>();
        lantern = GetComponent<LanternNEW>();
        flatten = GetComponent<FlattenNEW>();
        characterController = GetComponent<CharacterController>();
        thirdPersonControllerNEW = GetComponent<ThirdPersonControllerNEW>();
        pauseMenu = GetComponent<PauseMenu>();
    }

    void Update()
    {
        if (!pauseMenu.isGamePaused || !pauseMenu.isInventory)
        {
            RevertShape();
            FrogCollider();
            GlideCollider();
        }
    }

    public void AuriShape()
    {
        frogModel.SetActive(false);
        glideModel.SetActive(false);
        glide.OffGlide();
        auriModel.SetActive(true);
    }

    public void FrogShape()
    {
        if (!pauseMenu.isGamePaused || !pauseMenu.isInventory)
        {
            auriModel.SetActive(false);
            glideModel.SetActive(false);
            lanternModel.SetActive(false);
            frogModel.SetActive(true);
        }
        
    }

    void FrogCollider()
    {
        if (frogModel.activeSelf)
        {
            characterController.center = new Vector3(0, 0.3f, 0);
            characterController.radius = 1;
            characterController.height = 1;
        }
        else
        {
            characterController.center = new Vector3(0, 1.38f, 0);
            characterController.radius = 0.5f;
            characterController.height = 2.75f;
        }
    }
    public void GlideShape()
    {
        if (!pauseMenu.isGamePaused && !pauseMenu.isInventory)
        {
            auriModel.SetActive(false);
            frogModel.SetActive(false);
            lanternModel.SetActive(false);
            glideModel.SetActive(true);
        }
    }

    public void GlideCollider()
    {
        if (glideModel.activeSelf)
        {
            characterController.height = 1;
            characterController.center = new Vector3(0, 1f, 0);

        }
        else
        {
            characterController.center = new Vector3(0, 1.38f, 0);
            characterController.radius = 0.3f;
            characterController.height = 2.75f;
        }
    }

    public void RevertShape()
    {
        if (characterController.collisionFlags != CollisionFlags.None && !lanternModel.activeSelf)
        {
            frogModel.SetActive(false);
            glideModel.SetActive(false);
            
            if(glideModel.activeSelf || glide.isGliding)
                glide.OffGlide();
            
            auriModel.SetActive(true);
        }
    }
}
