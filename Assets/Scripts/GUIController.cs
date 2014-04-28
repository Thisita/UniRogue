using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour
{
    //Config
    public GUISkin skin;

    GameManager gameManager;
	// Use this for initialization
	void Start()
    {
        // Get the game manager
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Creates GUI
	void OnGUI()
    {
        // Skin
        if (skin)
        {
            GUI.skin = skin;
        }
        // Get the game state
        GameManager.GameState gameState = gameManager.GetGameState();
        if (gameState == GameManager.GameState.GameOver)
        {
            // Render game over
            OnGameOverGUI();
        }
        else if (gameState == GameManager.GameState.Paused)
        {
            // Render paused
            OnPausedGUI();
        }
        else if (gameState == GameManager.GameState.Playing)
        {

        }
	}

    // Render paused GUI
    void OnPausedGUI()
    {
        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Paused");
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
    }

    // Render paused GUI
    void OnGameOverGUI()
    {
        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Game Over");
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
    }
}
