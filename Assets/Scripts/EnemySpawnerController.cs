﻿using UnityEngine;
using System.Collections;

public class EnemySpawnerController : MonoBehaviour
{
    // Enemies to randomly be spawned
    public Transform[] enemies;
    // Delta between spawns
    public float delta = 30.0f;

    float lastTime;

    // Start is caled at first run
    void Start()
    {
        // set lastTime
        lastTime = Time.time;
    }
	
	// Update is called once per frame
	void Update()
    {
        // Test if it is a spawn time
        if ((Time.time - lastTime) >= delta)
        {
            // instantiate a new object at the spawner
            Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(0, 0, 0), Quaternion.identity);
        }
	}
}
