using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    int eneimesToKill;

	// Use this for initialization
	void Start () {
        eneimesToKill = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int GetNumEneimesToKill()
    {
        return eneimesToKill;
    }

    public void IncreaseEnemies(int num)
    {
        eneimesToKill += num;
    }

    public void DecreaseEnemies(int num)
    {
        eneimesToKill -= num;
    }
}
