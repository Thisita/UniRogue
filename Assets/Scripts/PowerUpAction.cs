using UnityEngine;
using System.Collections;

public class PowerUpAction : MonoBehaviour {
	public string type;
	PlayerHealth playerhealth;
	// Use this for initialization
	void Start () {
		playerhealth = GameObject.FindObjectOfType<PlayerHealth>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if (!other.Equals (null)&&other.name=="Player") 
		{
			Debug.Log("Hit object: " + other.name);
			switch(type)
			{
				case "health":
				playerhealth.GainHealth(20);
					break;
				case "shield":
				playerhealth.GiveShield(5);
					break;
				default:
					break;
			}
			Destroy (gameObject);
		}
	}
}
