using UnityEngine;
using System.Collections;

public class SpawnPlatform : MonoBehaviour {

    public Transform spawnPoint;
    public Warp warp;
    public GameObject[] platforms;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject newPlatform = (GameObject)Instantiate(platforms[0], spawnPoint.position, Quaternion.identity);

            Warp otherWarp = newPlatform.GetComponentInChildren<Warp>();

            if (otherWarp != null)
            {

                GameObject warpPoint = new GameObject("spawnedWarpPoint");
                warpPoint.transform.position = otherWarp.transform.position;
                warpPoint.transform.parent = otherWarp.gameObject.transform;
                warpPoint.transform.Translate(0, 1, -10);
                warp.warpTransform = warpPoint.transform;
            }
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
