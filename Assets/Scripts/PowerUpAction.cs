using UnityEngine;
using System.Collections;

public class PowerUpAction : MonoBehaviour {
	public string type;
	PlayerHealth gameManager;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<PlayerHealth>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if (!other.Equals (null)) 
		{
			Debug.Log ("Colliding");
			switch(type)
			{
				case "health":
				gameManager.GainHealth(20);
					break;
				case "shield":
					break;
				default:
					break;
			}
			Destroy (gameObject);
		}
	}
}
