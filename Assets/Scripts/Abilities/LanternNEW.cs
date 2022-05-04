using System.Collections;
using UnityEngine;

public class LanternNEW : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Light lanternLight;

    public bool isLantern;
    public float fireBallHeight = 1f;
    public bool lanternFire = false;
    public float maxTime = 10f;
    public float reloadTime = 1f;
    public float projectileSpeed = 500f;
    public float projectileDespawn = 3f;
    public float currentTime;
    GameObject lanternReticle;

    GlideNEW glide;
    FrogJumpNEW frogJump;
    AudioManager audioManager;
    ChangeShape changeShape;
    ThirdPersonControllerNEW thirdPersonControllerNEW;
    CameraManagerNEW cameraManager;
    PauseMenu pauseMenu;
    UnlockAbility unlockAbility;

    public AbilityTimer abilityTimer;
    public GameObject abilityMeter;

    
    void Awake()
    {
        glide = GetComponent<GlideNEW>();
        frogJump = GetComponent<FrogJumpNEW>();
        audioManager = GetComponent<AudioManager>();
        changeShape = GetComponent<ChangeShape>();
        thirdPersonControllerNEW = GetComponent<ThirdPersonControllerNEW>();
        cameraManager = GetComponent<CameraManagerNEW>();
        pauseMenu = GetComponent<PauseMenu>();
        unlockAbility = GetComponent<UnlockAbility>();

    }

    void Update()
    {
        if (currentTime >= maxTime)
            currentTime = maxTime;
        
        if(isLantern)
        {
            currentTime += Time.deltaTime;

            abilityMeter.SetActive(true);
            abilityTimer.SetMaxTime(maxTime);
            abilityTimer.SetTime(currentTime);
        }
        
        if(!isLantern && !glide.isGliding)
            abilityMeter.SetActive(false);

    }
    
    private void Start()
    {
        // Imari - Grabs the lantern reticle from the main camera UI
        lanternReticle = cameraManager.mainCamera.GetChild(0).GetChild(1).gameObject;
    }

    public void OnLantern()
    {
        if (unlockAbility.lanternUnlocked)
        {
            if (!pauseMenu.isGamePaused && !pauseMenu.isInventory)
            {
                if (!isLantern)
                {
                    lanternReticle.SetActive(true);
                    isLantern = true;
                    glide.isGliding = false;
                    frogJump.isFrogJumping = false;
                    changeShape.auriModel.SetActive(false);
                    changeShape.frogModel.SetActive(false);
                    changeShape.glideModel.SetActive(false);
                    changeShape.lanternModel.SetActive(true);

                    if(isLantern)
                    {
                        thirdPersonControllerNEW.doubleJump = false;
                        thirdPersonControllerNEW.jumpsRemaining = 0;
                    }

                    thirdPersonControllerNEW.gravity = 0f;
                    thirdPersonControllerNEW.verticalVelocity = 0f;

                    audioManager.IsTransforming();
                    audioManager.LanternIsOn();

                    lanternLight.enabled = true;
                    lanternFire = true;
                    Debug.Log("Lantern is working.");
                    StartCoroutine(LanternTime());
                }
                else
                {
                    OffLantern();
                }
            }
        }
    }

    public void OnLanternFire()
    {
        if (lanternFire && isLantern)
        {
            float targetRotation = Mathf.Atan2(gameObject.transform.rotation.x, gameObject.transform.rotation.z) * Mathf.Rad2Deg + cameraManager.mainCamera.eulerAngles.y;
            Vector3 targetDirection = Quaternion.Euler(-cameraManager.mainCamera.eulerAngles.x, targetRotation, 0.0f) * Vector3.back;

            GameObject bullet = Instantiate(projectilePrefab, transform.position + new Vector3(0, fireBallHeight, 0), Quaternion.Euler(-cameraManager.mainCamera.eulerAngles.x, targetRotation, 0.0f));

            bullet.GetComponent<Rigidbody>().AddForce(targetDirection * projectileSpeed);
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), this.GetComponent<CharacterController>());

            Destroy(bullet, projectileDespawn);
            lanternFire = false;
            StartCoroutine(Reload());
            audioManager.FireBall();
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        lanternFire = true;
    }

    IEnumerator LanternTime()
    {
        yield return new WaitForSeconds(maxTime);
        OffLantern();
    }

    public void OffLantern()
    {
        StopAllCoroutines();
        currentTime = 0;
        lanternReticle.SetActive(false);
        thirdPersonControllerNEW.gravity = -15;
        lanternLight.enabled = false;
        changeShape.auriModel.SetActive(true);
        changeShape.lanternModel.SetActive(false);
        isLantern = false;
        audioManager.LanternIsOff();
    }
}
