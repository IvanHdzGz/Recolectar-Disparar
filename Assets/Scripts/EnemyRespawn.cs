using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyRespawn : MonoBehaviour
{
    public float respawnTime = 5f;
    private Vector3 startPosition;
    private NavMeshAgent agent;
    private Renderer[] renderers;
    private Collider[] colliders;
    public AudioClip destroySound;
    public GameObject deathVFX;

    void Start()
    {
        startPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("No hay NavMeshAgent en: " + gameObject.name);
        }
        renderers = GetComponentsInChildren<Renderer>();
        colliders = GetComponentsInChildren<Collider>();
    }
    public void Die()
    {
        if (deathVFX != null)
        {
            GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);

            ParticleSystem ps = vfx.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
            }
        }

        if (destroySound != null)
        {
            AudioSource.PlayClipAtPoint(destroySound, transform.position);
        }

        StartCoroutine(RespawnRoutine());
    }
    IEnumerator RespawnRoutine()
    {
        // desactivar comportamiento
        if (agent != null)
            agent.enabled = false;

        foreach (Renderer r in renderers)
            r.enabled = false;

        foreach (Collider c in colliders)
            c.enabled = false;

        yield return new WaitForSeconds(respawnTime);

        // restaurar
        transform.position = startPosition;

        if (agent != null)
            agent.enabled = true;

        foreach (Renderer r in renderers)
            r.enabled = true;

        foreach (Collider c in colliders)
            c.enabled = true;
    }
}