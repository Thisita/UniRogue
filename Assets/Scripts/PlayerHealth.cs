using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public float playerHealth = 100f;
    float currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = playerHealth;
	}

    void TakeDamage(float amt)
    {
        currentHealth -= amt;

        if (currentHealth <=0 )
        {
            Die();
        }
    }

    void Die()
    {

    }
	
}
