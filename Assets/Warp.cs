using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

    public Transform warpTransform;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Trigger");

        other.transform.position = warpTransform.position;
    }
}
