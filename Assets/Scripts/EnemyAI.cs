﻿using UnityEngine;
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
        // log
        Debug.Log("EnemyAI::Start()");
        // Get the player
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update()
    {
        // Track the player via rotation
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

        // should we chase?
        if (Vector3.Distance(transform.position, player.transform.position) >= minDistance)
        {
            // log
            //Debug.Log("EnemyAI::Update() [Chasing]");
            // chase
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            // Can we attack?
            if (Vector3.Distance(transform.position, player.transform.position) <= maxDistance)
            {
                // log
                //Debug.Log("EnemyAI::Update() [Attacking]");
                // attack
                Attack();
            }
        }
	}

    // Carries out an attack operation on the player
    void Attack()
    {
        // log
        //Debug.Log("EnemyAI::Attack()");
        // TODO: Implement
    }
}
