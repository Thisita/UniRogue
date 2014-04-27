using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public float playerHealth = 100f;
    float currentHealth;

    GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        currentHealth = playerHealth;
	}

    public void TakeDamage(float amt)
    {
        currentHealth -= amt;

        if (currentHealth <=0 )
        {
            Die();
        }
    }

    void Die()
    {
        gameManager.SetGameState(GameManager.GameState.GameOver);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 60, 20), currentHealth + "/" + playerHealth);
    }
	
}
