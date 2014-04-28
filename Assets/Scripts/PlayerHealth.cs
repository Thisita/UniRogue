﻿using UnityEngine;
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

        if (currentHealth <= 0)
        {
            Die();
        }
    }
	public void GainHealth(float amt){
		currentHealth += amt;
		if (currentHealth > 100) {
			currentHealth=100;
		}
	}

    void Die()
    {
        gameManager.SetGameState(GameManager.GameState.GameOver);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 160, 25), "Player Health: " + currentHealth + "/" + playerHealth);
    }
	
}
