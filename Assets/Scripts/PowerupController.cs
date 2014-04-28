﻿using UnityEngine;
using System.Collections;

public class PowerupController : MonoBehaviour {

	public ParticleSystem[] powerups;
	GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Generate(Transform t){
		ParticleSystem powerup = Instantiate (powerups [Random.Range (0, powerups.Length)]) as ParticleSystem;
		powerup.transform.position = t.position;
		powerup.Play ();
		Debug.Log(powerup.duration);
		Destroy (powerup.gameObject,powerup.duration);
	}
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Colliding");
	}
}