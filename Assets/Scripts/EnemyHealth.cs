using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public float hitPoints = 100f;
    float currentHitPoints;

    GameManager gameManager;

	// Use this for initialization
	void Start () {
        currentHitPoints = hitPoints;
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}

    public void TakeDamage(float amt)
    {
        currentHitPoints -= amt;

        if (currentHitPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (gameManager.GetNumEneimesToKill() > 0)
            gameManager.DecreaseEnemies(1);
        Destroy(gameObject);
    }
	
}
