using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyRespawn : MonoBehaviour {
    public float respawnTime = 5f;
    private Vector3 startPosition;
    private NavMeshAgent agent;
    private Renderer[] renderers;
    private Collider[] colliders;

    void Start() {
        startPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();
        renderers = GetComponentsInChildren<Renderer>();
        colliders = GetComponentsInChildren<Collider>();
    }
    public void Die() {
        StartCoroutine(RespawnRoutine());
    }
    IEnumerator RespawnRoutine() {
        agent.enabled = false;
        foreach (Renderer r in renderers)
            r.enabled = false;

        foreach (Collider c in colliders)
            c.enabled = false;

        yield return new WaitForSeconds(respawnTime);

        transform.position = startPosition;
        agent.enabled = true;

        foreach (Renderer r in renderers)
            r.enabled = true;

        foreach (Collider c in colliders)
            c.enabled = true;
    }
}