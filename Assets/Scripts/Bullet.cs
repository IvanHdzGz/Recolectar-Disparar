using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    public void Shoot(Vector3 direction)
    {
        GetComponent<Rigidbody>().linearVelocity = direction * speed;
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Golpeó: " + collision.gameObject.name);

        EnemyRespawn enemy =
            collision.gameObject.GetComponentInParent<EnemyRespawn>();

        if (enemy != null)
        {
            Debug.Log("Encontró EnemyRespawn");
            enemy.Die();
        }

        Destroy(gameObject);
    }
}