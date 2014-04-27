using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

    public Transform warpTransform;

    GameManager gameManager;

    void Start()
    {
        // There should only be one game manager
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (gameManager.GetNumEneimesToKill() == 0)
        {
            Debug.Log("Entered Trigger");

            other.transform.position = warpTransform.position;
        }
    }
}
