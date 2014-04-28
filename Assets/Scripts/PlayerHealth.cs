using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public float playerHealth = 100f;
    float currentShields;
    float currentHealth;

    GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        currentHealth = playerHealth;
        currentShields = 0;
	}

    public void TakeDamage(float amt)
    {
		if (currentShields>amt) {
			currentShields=currentShields-amt;
		}
		else{
			if (currentShields==0){
				currentHealth -= amt;
			}
			else{
				currentHealth =currentHealth- amt+currentShields;
				currentShields=0;
			}

	        if (currentHealth <= 0)
	        {
	            Die();
	        }
		}
    }
	public void GainHealth(float amt){
		currentHealth += amt;
		if (currentHealth > 100) {
			currentHealth=100;
		}
	}
	public void GiveShield(float amt){
		currentShields += amt;
	}
    void Die()
    {
        gameManager.SetGameState(GameManager.GameState.GameOver);
    }

    void OnGUI()
    {
        GUIStyle gs = GUI.skin.GetStyle("Box");
        gs.alignment = TextAnchor.MiddleLeft;

        if (currentShields == 0)
        {
            GUI.Box(new Rect(10, 10, 150, 25), "Player Health: " + currentHealth + "/" + playerHealth, gs);
        }
        else
        {
            GUI.Box(new Rect(10, 10, 150, 50), "Player Health: " + currentHealth + "/" + playerHealth + "\nPlayer Shields: " + currentShields, gs);
        }

        gs.alignment = TextAnchor.MiddleCenter;
    }
	
}
