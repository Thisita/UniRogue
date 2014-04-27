using UnityEngine;
using System.Collections;

public class EnemySpawnerController : MonoBehaviour
{
    // Enemies to randomly be spawned
    public GameObject[] enemies;
    // Delta between spawns
    public float delta = 30.0f;

    float lastTime;

    // Start is caled at first run
    void Start()
    {
        // set lastTime
        lastTime = 0;
    }
	
	// Update is called once per frame
	void Update()
    {
        lastTime += Time.deltaTime;
        // Test if it is a spawn time
        if (lastTime >= delta)
        {
            Debug.Log("Spawning Enemy");
            lastTime = 0;
            // instantiate a new object at the spawner
            Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, Quaternion.identity);
        }
	}
}
