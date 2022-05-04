using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class InputManagerNEW : MonoBehaviour
{
	[Header("Character Input Values")]
	public Vector2 move;
	public Vector2 look;
	public bool jump;
	public bool sprint;
	public bool flattenX;
	public bool flattenY;
	public bool glide;
	public bool lantern;
	public bool lanternFire;
	public bool pause;
	public bool inventory;
	public bool interact;
	public bool compass;
	public float horizontalInput;
	public float verticalInput;
	

	private GlideNEW glideNEW;
	private ThirdPersonControllerNEW thirdPersonControllerNew;

	[Header("Movement Settings")]
	public bool analogMovement;

	[Header("Mouse Cursor Settings")]
	public bool cursorLocked = true;
	public bool cursorInputForLook = true;

	private void Awake()
	{
		glideNEW = GetComponent<GlideNEW>();
		thirdPersonControllerNew = GetComponent<ThirdPersonControllerNEW>();
	}

	private void Update()
	{
		if (glideNEW.isGliding)
		{
			move = Vector2.up;
		}
	}

	public void OnMove(InputValue value)
	{
		MoveInput(value.Get<Vector2>());
	}

	public void OnLook(InputValue value)
	{
		if (cursorInputForLook)
			LookInput(value.Get<Vector2>());
	}

	public void OnJump(InputValue value)
	{
		JumpInput(value.isPressed);
	}

	public void OnSprint(InputValue value)
	{
		SprintInput(value.isPressed);
	}
	public void OnFlattenX(InputValue value)
	{
		FlattenXInput(value.isPressed);
	}

	public void OnFlattenY(InputValue value)
	{
		FlattenYInput(value.isPressed);
	}

	public void OnGlide(InputValue value)
	{
		GlideInput(value.isPressed);
	}
	public void OnLantern(InputValue value)
	{
		LanternInput(value.isPressed);
	}

	public void OnLanternFire(InputValue value)
    {
		LanternFireInput(value.isPressed);
    }
	
	public void OnPause(InputValue value)
	{
		PauseInput(value.isPressed);
	}

	public void OnInventory(InputValue value)
	{
		InventoryInput(value.isPressed);
	}

	public void OnInteract(InputValue value)
    {
		InteractInput(value.isPressed);
    }
	public void OnCompass(InputValue value)
    {
		CompassInput(value.isPressed);
    }

	public void MoveInput(Vector2 newMoveDirection)
	{
		move = newMoveDirection;
		horizontalInput = move.x;
		verticalInput = move.y;
	}

	public void LookInput(Vector2 newLookDirection)
	{
		look = newLookDirection;
	}

	public void JumpInput(bool newJumpState)
	{
		jump = newJumpState;
	}

	public void SprintInput(bool newSprintState)
	{
		sprint = newSprintState;
	}

	public void FlattenXInput(bool newFlattenXState)
	{
		flattenX = newFlattenXState;
	}
	public void FlattenYInput(bool newFlattenYState)
	{
		flattenY = newFlattenYState;
	}
	public void GlideInput(bool newGlideState)
	{
		glide = newGlideState;
	}
	public void LanternInput(bool newLanternState)
	{
		lantern = newLanternState;
	}

	public void LanternFireInput(bool newLanternFireState)
    {
		lanternFire = newLanternFireState;
    }

	public void PauseInput(bool newPauseState)
	{
		pause = newPauseState;
	}

	public void InventoryInput(bool newInventoryState)
	{
		inventory = newInventoryState;
	}

	public void InteractInput(bool newInteractInput)
    {
		interact = newInteractInput;
    }
	public void CompassInput(bool newCompassInput)
    {
		compass = newCompassInput;
    }

	void OnApplicationFocus(bool hasFocus)
	{
		SetCursorState(cursorLocked);
	}

	void SetCursorState(bool newState)
	{
		Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
	}
}