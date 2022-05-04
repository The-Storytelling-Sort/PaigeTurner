using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ThirdPersonControllerNEW : MonoBehaviour
{
	[Header("Player")]
	[SerializeField] public float moveSpeed = 2.0f;
	[SerializeField] float sprintSpeed = 5.335f;
	[Range(0.0f, 0.3f)]
	[SerializeField] float rotationSpeed = 0.12f;
	[Tooltip("Acceleration and deceleration")]
	public float speedChangeRate = 10.0f;

	[Space(10)]
	[SerializeField] float jumpSpeed;
	public float jumpHeight = 1.2f;
	public float gravity = -15.0f;
	public bool doubleJump;
	public int jumpsRemaining = 2;

	[Space(10)]
	[Tooltip("Time required to pass before being able to jump again. Set to 0f to instantly jump again")]
	[SerializeField] float jumpDelay = 0.50f;
	[Tooltip("Time required to pass before entering the fall state. Useful for walking down stairs")]
	[SerializeField] float fallDelay = 0.15f;

	[Header("Player Grounded")]
	public bool grounded = true;
	[SerializeField] float groundedOffset = -0.14f;
	[Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
	[SerializeField] float groundedRadius = 0.28f;
	[Tooltip("What layers the character uses as ground")]
	[SerializeField] LayerMask ground;

	public Vector3 targetDirection;
	public float targetSpeed;
    public float inputMagnitude;
	public float speed;
	public float targetRotation = 0.0f;
	float rotationVelocity;
	public float verticalVelocity;
	public float horizontalVelocity = 0.0f;
	float terminalVelocity = 53.0f;

	float jumpDelayDelta;
	float fallDelayDelta;

	float elapsedTime;

	public bool isSlowed;

	CharacterController characterController;
	InputManagerNEW inputManager;
	CameraManagerNEW cameraManager;
	AnimatorManagerNEW animatorManager;
	FrogJumpNEW frogJump;
	ClimbNEW climbNEW;
	AudioManager audioManager;

	void Start()
	{
		characterController = GetComponent<CharacterController>();
		inputManager = GetComponent<InputManagerNEW>();
		cameraManager = GetComponent<CameraManagerNEW>();
		animatorManager = GetComponent<AnimatorManagerNEW>();
		frogJump = GetComponent<FrogJumpNEW>();
		climbNEW = GetComponent<ClimbNEW>();
		audioManager = GetComponent<AudioManager>();

		jumpDelayDelta = jumpDelay;
		fallDelayDelta = fallDelay;

		
	}

	void Update()
	{
		GroundedCheck();
		Jump();
		Move();
		SoundForMoveJump();

		
		if (speed == 0 && this.isActiveAndEnabled)
        {
			elapsedTime += Time.deltaTime;
			if(elapsedTime >= 15)
            {
				animatorManager.SetIdleWave();
				elapsedTime = 0;
            }
		}
		else if (speed > 0)
        {
			animatorManager.SetIdleWaveFalse();
			elapsedTime = 0;
        }
	}

	void GroundedCheck()
	{
		if (climbNEW.isClimbing)
			return;

		// set sphere position, with offset
		Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z);
		grounded = Physics.CheckSphere(spherePosition, groundedRadius, ground, QueryTriggerInteraction.Ignore);

		// update animator if using character
		if (animatorManager.hasAnimator)
			animatorManager.SetGroundedAnimation();
	}

	void Move()
	{
		if (climbNEW.isClimbing)
			return;

		// set target speed based on move speed, sprint speed and if sprint is pressed
		targetSpeed = inputManager.sprint ? sprintSpeed : moveSpeed;

		// if there is no input, set the target speed to 0
		if (inputManager.move == Vector2.zero)
			targetSpeed = 0.0f;

		// a reference to the players current horizontal velocity
		float currentHorizontalSpeed = new Vector3(characterController.velocity.x, 0.0f, characterController.velocity.z).magnitude;

		float speedOffset = 0.1f;
		inputMagnitude = inputManager.analogMovement ? inputManager.move.magnitude : 1f;

		// accelerate or decelerate to target speed
		if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
		{
			speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude, Time.deltaTime * speedChangeRate);
			speed = Mathf.Round(speed * 1000f) / 1000f;
		}
		else
			speed = targetSpeed;

		/*if (climbNEW.isClimbing)
			return;*/

		animatorManager.BlendAnimations();

		// normalize input direction
		Vector3 inputDirection = new Vector3(inputManager.move.x, 0.0f, inputManager.move.y).normalized;

		// if there is a move input rotate player when the player is moving
		if (inputManager.move != Vector2.zero)
		{
			targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cameraManager.mainCamera.eulerAngles.y;
			float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref rotationVelocity, rotationSpeed);

			// rotate to face input direction relative to camera position
			transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
		}

		targetDirection = Quaternion.Euler(0.0f, targetRotation, 0.0f) * Vector3.forward;

		// move the player
		characterController.Move(targetDirection.normalized * (speed * Time.deltaTime) + new Vector3(horizontalVelocity, verticalVelocity, 0.0f) * Time.deltaTime);

		// update animator if using character
		if (animatorManager.hasAnimator)
			animatorManager.BlendAnimations();
	}

	void Jump()
	{
		if (grounded)
		{
			jumpsRemaining = 2;

			// reset the fall timeout timer
			fallDelayDelta = fallDelay;

			// update animator if using character
			if (animatorManager.hasAnimator)
				if (climbNEW.isClimbing)
					animatorManager.SetClimbAnimation();
				else
					animatorManager.SetGroundedAnimation();

			// stop our velocity dropping infinitely when grounded
			if (verticalVelocity < 0.0f)
				verticalVelocity = -2f;

			// Jump
			if (inputManager.jump && jumpDelayDelta <= 0.0f)
			{
				if (climbNEW.isClimbing)
					climbNEW.isClimbing = false;

				inputManager.flattenX = false;
				inputManager.flattenY = false;

				// the square root of H * -2 * G = how much velocity needed to reach desired height
				verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
				inputManager.sprint = false;

				// update animator if using character
				if (animatorManager.hasAnimator)
					animatorManager.SetJumpAnimation();
			}

			// jump timeout
			if (jumpDelayDelta >= 0.0f)
				jumpDelayDelta -= Time.deltaTime;
		}
		else
		{
			doubleJump = true;
			inputManager.sprint = false;
			audioManager.NotRunning();
			audioManager.NotWalking();

			if (doubleJump)
			{
				if (inputManager.jump && jumpsRemaining >= 0)
                {
					jumpsRemaining--;

					if (jumpsRemaining == 0)
						frogJump.OnFrogJump();
				}
				doubleJump = false;
			}

			// reset the jump timeout timer
			jumpDelayDelta = jumpDelay;

			// fall timeout
			if (fallDelayDelta >= 0.0f)
				fallDelayDelta -= Time.deltaTime;
			else
			{
				// update animator if using character
				if (animatorManager.hasAnimator)
					animatorManager.SetFallAnimation();
			}
			
			// if we are not grounded, do not jump
			inputManager.jump = false;
			frogJump.isFrogJumping = false;
		}

		// apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
		if (verticalVelocity < terminalVelocity)
			verticalVelocity += gravity * Time.deltaTime;
	}

	void OnDrawGizmosSelected()
	{
		Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
		Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

		if (grounded) Gizmos.color = transparentGreen;
		else Gizmos.color = transparentRed;

		// when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
		Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z), groundedRadius);
	}

	public void FreezePlayer()
    {
		moveSpeed = 0;
		sprintSpeed = 0;
    }

	public void ResumePlayer()
    {
		moveSpeed = 8;
		sprintSpeed = 8;
	}

	//Sounds for running & Jumping
	void SoundForMoveJump()
    {
		if (speed == 0)
		{
			audioManager.NotWalking();
			audioManager.NotRunning();
		}
        else
        {
			audioManager.IsRunning();
		}

        if (grounded == false)
		{ 
			audioManager.NotWalking();
			audioManager.NotRunning();
		}
    }
	public IEnumerator Slowdown()
    {
		isSlowed = true;
		moveSpeed =4 ;
		yield return new WaitForSeconds(3);
		isSlowed = false;
		moveSpeed = 8;
		
    }
}