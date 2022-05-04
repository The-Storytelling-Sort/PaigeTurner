using UnityEngine;

public class ClimbNEW : MonoBehaviour
{
    public bool isClimbing;

    ThirdPersonControllerNEW thirdPersonController;
    InputManagerNEW inputManager;
    CharacterController characterController;
    AnimatorManagerNEW animatorManager;
    Vector3 moveDirection;

    void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonControllerNEW>();
        inputManager = GetComponent<InputManagerNEW>();
        characterController = GetComponent<CharacterController>();
        animatorManager = GetComponent<AnimatorManagerNEW>();
    }

    void FixedUpdate()
    {
        if (isClimbing)
            Climb();
    }

    void Climb()
    {
        animatorManager.SetClimbAnimation();

        thirdPersonController.grounded = true;
        thirdPersonController.verticalVelocity = thirdPersonController.horizontalVelocity;

        thirdPersonController.speed = thirdPersonController.moveSpeed;

        moveDirection = transform.up * inputManager.verticalInput;
        moveDirection = moveDirection + transform.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        //Debug.Log(moveDirection);

        characterController.Move(moveDirection.normalized * (thirdPersonController.speed * Time.deltaTime) 
            + new Vector3(thirdPersonController.horizontalVelocity, thirdPersonController.verticalVelocity, 0.0f) * Time.deltaTime);

        animatorManager.BlendClimbAnimations();
    }
}
