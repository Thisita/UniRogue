using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public enum GameState
    {
        Paused,
        Playing
    }

    int eneimesToKill;
    GameState state;
    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        state = GameState.Playing;
        eneimesToKill = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch(state)
            {
                case GameState.Paused:
                    player.GetComponent<MouseLook>().enabled = true;
                    Camera.main.GetComponent<MouseLook>().enabled = true;
                    state = GameState.Playing;
                    break;
                case GameState.Playing:
                    player.GetComponent<MouseLook>().enabled = false;
                    Camera.main.GetComponent<MouseLook>().enabled = false;
                    state = GameState.Paused;
                    break;
                default:
                    break;
            }
        }

        if (state == GameState.Paused)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
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

    public GameState GetGameState()
    {
        return state;
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
