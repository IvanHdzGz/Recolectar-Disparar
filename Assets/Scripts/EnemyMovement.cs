using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement: MonoBehaviour {
	public Transform player;
	private NavMeshAgent navMeshAgent;
	void Start() {
		navMeshAgent = GetComponent < NavMeshAgent > ();
	}
	void Update()
	{
    	if (player != null && navMeshAgent.enabled && navMeshAgent.isOnNavMesh)
    	{
        	navMeshAgent.SetDestination(player.position);
    	}
	}
		void OnCollisionEnter(Collision collision)
	{
    	if (collision.gameObject.CompareTag("Player"))
    	{
        	PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();

	        if (health != null)
    	    {
        	    health.TakeDamage(5);
        	}
    	}
	}
}