using UnityEngine;
public class MouseCameraController: MonoBehaviour {
	public Transform player;
	public float mouseSensitivity = 200f;
	public float distanceFromPlayer = 5f;
	float xRotation = 0f;
	float yRotation = 0f;
	void Start() {
		Cursor.lockState = CursorLockMode.Locked;
	}
	void Update() {
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
		yRotation += mouseX;
		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -30f, 60f);
	}
	void LateUpdate() {
		if(player == null) return;
		Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0);
		Vector3 position = player.position - (rotation * Vector3.forward * distanceFromPlayer);
		transform.position = position;
		transform.LookAt(player);
	}
}