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
        EnemyRespawn enemy = collision.gameObject.GetComponentInParent<EnemyRespawn>();

        if (enemy != null)
        {
            if (enemy.destroySound != null)
            {
                AudioSource.PlayClipAtPoint(enemy.destroySound, collision.transform.position);
            }

            Destroy(enemy.gameObject);
        }

        Destroy(gameObject);
    }
}