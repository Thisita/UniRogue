using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    // Some configuration
    public Transform player;
    public float moveSpeed;
    public float minDistance;
    public float maxDistance;

	// Use this for initialization
	void Start()
    {
	    
	}
	
	// Update is called once per frame
	void Update()
    {
        // Track the player via rotation
        transform.LookAt(player);

        // should we chase?
        if (Vector3.Distance(transform.position, player.position) >= minDistance)
        {
            // chase
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            // Can we attack?
            if (Vector3.Distance(transform.position, player.position) <= maxDistance)
            {
                // attack
                Attack();
            }
        }
	}

    // Carries out an attack operation on the player
    void Attack()
    {
        // TODO: Implement
    }
}
