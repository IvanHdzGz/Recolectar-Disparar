using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController: MonoBehaviour {
	private Rigidbody rb;
	private int count;
	private float movementX;
	private float movementY;
	public float speed = 0;
	public float jumpForce = 7f;
	public GameObject bulletPrefab;
	public Transform firePoint;
	public float shootForce = 20f;
	bool isGrounded;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;
	
	void Start() {
		rb = GetComponent < Rigidbody > ();
		count = 0;
		SetCountText();
		winTextObject.SetActive(false);
	}
	void OnMove(InputValue movementValue) {
		Vector2 movementVector = movementValue.Get < Vector2 > ();
		movementX = movementVector.x;
		movementY = movementVector.y;
	}
	void FixedUpdate() {
    	isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
    	Vector3 camForward = Camera.main.transform.forward;
    	Vector3 camRight = Camera.main.transform.right;
    	camForward.y = 0;
    	camRight.y = 0;
    	camForward.Normalize();
    	camRight.Normalize();
    	Vector3 moveDir = camForward * movementY + camRight * movementX;
    	rb.AddForce(moveDir * speed);
	}
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("PickUp")) {
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}
	}
	void SetCountText() {
		countText.text = "Count: " + count.ToString();
		if(count >= 40) {
			winTextObject.SetActive(true);
			Destroy(GameObject.FindGameObjectWithTag("Enemy"));
		}
	}
	private void OnCollisionEnter(Collision collision) {
    	if (collision.gameObject.CompareTag("Enemy")) {
        	PlayerHealth health = GetComponent<PlayerHealth>();

        	if (health != null)
        	{
           		health.TakeDamage(5);
        	}
    	}
	}
	void OnJump() {
    	if (isGrounded) {
        	rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    	}
	}
	void OnAttack() {
    	GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    	Vector3 shootDirection = Camera.main.transform.forward;
   		shootDirection.y = 0;
    	bullet.GetComponent<Bullet>().Shoot(shootDirection.normalized);
	}
}