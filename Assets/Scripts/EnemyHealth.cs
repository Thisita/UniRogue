using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public float hitPoints = 100f;
    float currentHitPoints;

    GameManager gameManager;
	PowerupController Powerup;
	// Use this for initialization
	void Start () {
        currentHitPoints = hitPoints;
        gameManager = GameObject.FindObjectOfType<GameManager>();
		Powerup = GameObject.FindObjectOfType < PowerupController> ();
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
        if (gameManager.GetNumEneimesToKill () > 0) {
			gameManager.DecreaseEnemies (1);
			Powerup.Generate(gameObject.transform);
		}
        Destroy(gameObject);
    }

    void OnGUI()
    {
        Vector3 targetPos;
        targetPos = Camera.main.WorldToScreenPoint(transform.position);

        if (targetPos.z > 0)
        {
            GUI.Box(new Rect(targetPos.x, Screen.height - targetPos.y, 60, 20), currentHitPoints + "/" + hitPoints);
        }
    }
	
}
