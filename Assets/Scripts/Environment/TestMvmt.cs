using UnityEngine;
using System.Collections;
using Cinemachine;

public class TestMvmt : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook thirdPersonCam;
    [SerializeField] CinemachineFreeLook storyBookCam;

    public CharacterController controller;
    public Transform cam;
    public CameraChecker script;
    public Transform bookArea;
    public Transform worldArea;
    public GameObject Player;
    public GameObject Page2to3;
    public GameObject Page4to5;
    

    private CameraChecker camerachecker;

    public float speed = 10f;
    public float PageFlipTeleportDelay = 2.0f;
    public float PageDeletionDelay = 1.25f;

    public float TurnSmoothing = 0.1f;
    float turnSmoothVelocity;

    void OnEnable()
    {
        camerachecker = GameObject.FindObjectOfType<CameraChecker>();
        CameraSwitcher.Register(thirdPersonCam);
        CameraSwitcher.Register(storyBookCam);
        CameraSwitcher.SwitchCamera(thirdPersonCam);
        //Finds CameraChecker script to reference and registers all cameras assigned to character. 
    }

    void OnDisable()
    {
        CameraSwitcher.Unregister(thirdPersonCam);
        CameraSwitcher.Unregister(storyBookCam);
        //Unregisters Cameras if character is disabled. This can be commented out, but may be useful.
    }

    public void Teleport()
    {
        Player.transform.position = bookArea.transform.position;
        //Teleport to Book.
    }

    public void worldTeleport()
    {
        Player.transform.position = worldArea.transform.position;
        //Teleport Back to World.
    }

    public void DisablePage3()
    {
        Page2to3.gameObject.SetActive(false);
        //Disables the planes containing pages 2 and 3.
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, TurnSmoothing);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (camerachecker.is2D)
        {
            Debug.Log("It Worked!");
            if(CameraSwitcher.IsActiveCamera(thirdPersonCam))
            {
                CameraSwitcher.SwitchCamera(storyBookCam);
            }

            else if(CameraSwitcher.IsActiveCamera(storyBookCam))
            {
                CameraSwitcher.SwitchCamera(thirdPersonCam);
            }

            Invoke("Teleport", PageFlipTeleportDelay);

            camerachecker.is2D = false;
            // Checks the CameraChecker script for the is2d bool to be true, then switches the camera to the book. If false, it defaults to the Third Person Freelook.
            // Invokes the teleport to the book section after a timer set in the editor called PageFlipTeleportDelay so the Cinemachine cameras don't freak out.
        }

        if (camerachecker.is3D)
        {
            Debug.Log("It Worked!");
            if (CameraSwitcher.IsActiveCamera(thirdPersonCam))
            {
                CameraSwitcher.SwitchCamera(storyBookCam);
            }

            else if (CameraSwitcher.IsActiveCamera(storyBookCam))
            {
                CameraSwitcher.SwitchCamera(thirdPersonCam);
            }

            Invoke("worldTeleport", 0);

            camerachecker.is3D = false;

            // Same thing as above but with no teleport delay so that the camera trasition is smooth.
        }

        if (camerachecker.flipped2to3)
        {
            Page2to3.GetComponent<Animator>().Play("PageFlipAnimation");

            camerachecker.flipped2to3 = false;

            // Checks bool to trigger page animation.
        }

        if (camerachecker.flipped4to5)
        {
            Page4to5.GetComponent<Animator>().Play("PageFlipAnimation");
            Invoke("DisablePage3", PageDeletionDelay);
            //camerachecker.flipped4to5 = false;

            // Triggers flip animation and disables the planes containing page 2 and 3 after set deletion time.
        }

        //  if (is2D == false)
        //  {
        //      Debug.Log("2D");
        //    }

    }
}

