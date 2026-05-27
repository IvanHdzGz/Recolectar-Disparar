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
    private Animator animator;

    public AudioClip destroySound;
    public GameObject deathVFX;

    private bool isDead = false;

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

        animator = GetComponentInChildren<Animator>();
    }

    public void Die()
    {
        // Evita morir varias veces seguidas
        Debug.Log("ENEMIGO MURIÓ");

        if (isDead)
            return;

        // detener movimiento enemigo
        if (agent != null)
        {
            agent.isStopped = true;
            agent.enabled = false;
        }

        // reproducir animación de muerte
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        // reproducir VFX
        if (deathVFX != null)
        {
            GameObject vfx =
                Instantiate(deathVFX,
                            transform.position,
                            Quaternion.identity);

            ParticleSystem ps = vfx.GetComponent<ParticleSystem>();

            if (ps != null)
            {
                ps.Play();
            }
        }

        // reproducir sonido
        if (destroySound != null)
        {
            AudioSource.PlayClipAtPoint(
                destroySound,
                transform.position
            );
        }

        StartCoroutine(RespawnRoutine());
    }

    IEnumerator RespawnRoutine()
    {
        // esperar a que se vea la animación
        yield return new WaitForSeconds(1.5f);

        // ocultar enemigo
        foreach (Renderer r in renderers)
            r.enabled = false;

        foreach (Collider c in colliders)
            c.enabled = false;

        yield return new WaitForSeconds(respawnTime);

        // reaparecer
        transform.position = startPosition;

        foreach (Renderer r in renderers)
            r.enabled = true;

        foreach (Collider c in colliders)
            c.enabled = true;

        if (agent != null)
        {
            agent.enabled = true;
            agent.isStopped = false;
        }

        // reinicia animator
        if (animator != null)
        {
            animator.Rebind();
            animator.Update(0f);
        }

        isDead = false;
    }
}