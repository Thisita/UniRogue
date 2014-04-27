using UnityEngine;
using System.Collections;

public class EnemySpawnerController : MonoBehaviour
{
    // Enemies to randomly be spawned
    public GameObject[] enemies;
    // Delta between spawns
    public float delta = 30.0f;
    // Number of enemies to be spawn
    public int enemyCount = 5;

    float lastTime;

    // Start is caled at first run
    void Start()
    {
        // log
        Debug.Log("EnemySpawnController::Start()");
        // set lastTime
        lastTime = 0.0f;
    }
	
	// Update is called once per frame
	void Update()
    {
        // update lastTime
        lastTime += Time.deltaTime;
        // Test if it is a spawn time
        if (lastTime >= delta && enemyCount > 0)
        {
            // log
            Debug.Log("EnemySpawnController::Update() [Instantiating]");
            // Reset timer
            lastTime = 0.0f;
            // instantiate a new object at the spawner
            GameObject.Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, Quaternion.identity);
            enemyCount--;
        }
	}
}
