using UnityEngine;

public class MoveUpDown : MonoBehaviour {
    [Header("Movimiento")]
    public float amplitude = 2f;
    public float speed = 2f;
    private Vector3 startPos;

    [Header("Daño")]
    public int damage = 10;

    void Start() {
        startPos = transform.position;
    }
    void Update() {
        float yOffset = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = startPos + new Vector3(0, yOffset, 0);
    }
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}
