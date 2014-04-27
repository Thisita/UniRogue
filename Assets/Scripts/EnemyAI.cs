using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    // Some configuration
    GameObject player;
    public float moveSpeed;
    public float minDistance;
    public float maxDistance;

	// Use this for initialization
	void Start()
    {
        // Debug
        if (Debug.isDebugBuild)
        {
            Debug.Log("EnemyAI::Start()");
        }
        // Get the player
        player = GameObject.FindGameObjectWithTag("player");
	}
	
	// Update is called once per frame
	void Update()
    {
        // Track the player via rotation
        transform.LookAt(player.transform);

        // should we chase?
        if (Vector3.Distance(transform.position, player.transform.position) >= minDistance)
        {
            // Debug
            if (Debug.isDebugBuild)
            {
                Debug.Log("EnemyAI::Update() [Chasing]");
            }
            // chase
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            // Can we attack?
            if (Vector3.Distance(transform.position, player.transform.position) <= maxDistance)
            {
                // Debug
                if (Debug.isDebugBuild)
                {
                    Debug.Log("EnemyAI::Update() [Attacking]");
                }
                // attack
                Attack();
            }
        }
	}

    // Carries out an attack operation on the player
    void Attack()
    {
        // Debug
        if (Debug.isDebugBuild)
        {
            Debug.Log("EnemyAI::Attack()");
        }
        // TODO: Implement
    }
}
