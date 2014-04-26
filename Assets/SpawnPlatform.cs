using UnityEngine;
using System.Collections;

public class SpawnPlatform : MonoBehaviour {

    public Transform spawnPoint;
    public Warp warp;
    public GameObject[] platformPrefabs;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        GameObject newPlatform = (GameObject)Instantiate(platformPrefabs[0], spawnPoint.position, Quaternion.identity);

        Warp otherWarp = newPlatform.GetComponentInChildren<Warp>();

        if (otherWarp != null)
        {
            GameObject warpPoint = (GameObject)Instantiate(new GameObject("warpPoint"), otherWarp.transform.position, Quaternion.identity);
            warpPoint.transform.Translate(0, 1, -10);
            warp.warpTransform = warpPoint.transform;
        }
        
    }
}
