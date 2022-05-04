using UnityEngine;

public class CameraManagerNEW : MonoBehaviour
{
	[Header("Cinemachine")]
	[Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
	[SerializeField] GameObject cinemachineCameraTarget;
	[Tooltip("How far in degrees can you move the camera up")]
	[SerializeField] float topClamp = 70.0f;
	[Tooltip("How far in degrees can you move the camera down")]
	[SerializeField] float bottomClamp = -30.0f;

	[HideInInspector]
	public Transform mainCamera;

	float cinemachineTargetYaw;
	float cinemachineTargetPitch;
	const float threshold = 0.01f;

	InputManagerNEW input;

	void Awake()
	{
		mainCamera = Camera.main.transform;
		input = GetComponent<InputManagerNEW>();
	}

	void LateUpdate()
	{
		CameraRotation();
	}

	void CameraRotation()
	{
		// if there is an input and camera position is not fixed
		if (input.look.sqrMagnitude >= threshold)
		{
			cinemachineTargetYaw += input.look.x * Time.deltaTime;
			cinemachineTargetPitch += input.look.y * Time.deltaTime;
		}

		// clamp our rotations so our values are limited 360 degrees
		cinemachineTargetYaw = ClampAngle(cinemachineTargetYaw, float.MinValue, float.MaxValue);
		cinemachineTargetPitch = ClampAngle(cinemachineTargetPitch, bottomClamp, topClamp);

		// Cinemachine will follow this target
		cinemachineCameraTarget.transform.rotation = Quaternion.Euler(cinemachineTargetPitch, cinemachineTargetYaw, 0.0f);
	}

	static float ClampAngle(float lfAngle, float lfMin, float lfMax)
	{
		if (lfAngle < -360f) lfAngle += 360f;
		if (lfAngle > 360f) lfAngle -= 360f;
		return Mathf.Clamp(lfAngle, lfMin, lfMax);
	}
}
