using UnityEngine;
using System.Collections;

public class RotatingThirdPersonCamera : MonoBehaviour {

	public float mouseSensitivity = 10;
	public Transform target;
    public Vector3 offset;
	public float distanceFromTarget = 2;
	public Vector2 pitchMinMax = new Vector2 (-30, 85);

	public float acceleration = .12f;
	Vector3 rotationSmoothVelocity;
	Vector3 currentRotation;

	float yaw; 
	float pitch;

	public bool InvertPitch;
	
	void LateUpdate () {

        yaw += Input.GetAxis ("Mouse X") * mouseSensitivity;

		if (InvertPitch)
			pitch += Input.GetAxis ("Mouse Y") * mouseSensitivity;
		else 
			pitch += Input.GetAxis ("Mouse Y") * -mouseSensitivity;

		pitch = Mathf.Clamp (pitch, pitchMinMax.x, pitchMinMax.y);

		currentRotation = Vector3.SmoothDamp (currentRotation, new Vector3 (pitch, yaw), ref rotationSmoothVelocity, acceleration);

		transform.eulerAngles = currentRotation;

        transform.position = target.position + offset - (transform.forward * distanceFromTarget);

	}
}
