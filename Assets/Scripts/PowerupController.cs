using UnityEngine;
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
		if(Random.Range(0,100)>00){
			ParticleSystem powerup = Instantiate (powerups [0/*Random.Range (0, powerups.Length)*/]) as ParticleSystem;
			powerup.transform.position = t.position;
			powerup.Play ();
			Destroy (powerup.gameObject,powerup.duration);
		}
	}

}
