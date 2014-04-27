using UnityEngine;
using System.Collections;

public class EnableSpawners : MonoBehaviour {

    public EnemySpawnerController[] spawners;

    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (EnemySpawnerController spawner in spawners)
            {
                spawner.enabled = true;
                gameManager.IncreaseEnemies(spawner.enemyCount);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (EnemySpawnerController spawner in spawners)
            {
                spawner.enabled = false;
            }
        }
    }
}
