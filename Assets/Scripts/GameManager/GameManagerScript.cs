using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject player;
    //public GameObject mainCanvas;

    // So you can make reference to the gameOverCanvas:
    public GameObject gameOverCanvas;
    // So you can make reference to the EndScreenCanvas:
    public GameObject EndScreen;

    public enum GameStates
    {
        Playing,
        GameOver
    }

    public GameStates gameState = GameStates.Playing;
    private Health healthPlayer;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        healthPlayer = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        //State machine of the game

        switch (gameState)
        {
            case GameStates.Playing:
                if (!healthPlayer.isAlive)
                {
                    gameState = GameStates.GameOver;
                    //mainCanvas.SetActive(false);
                    gameOverCanvas.SetActive(true);
                    // Unlocks the cursor so you can press the buttons on the canvas:
                    Cursor.lockState = CursorLockMode.None;
                    // Stops the gameTime and Audio in game (if gameTime is not stopped wall will run you over and gameOverScreen will be called upon)
                    Invoke("PauzeGame", 1);
                    // If the player is alive and the EndScreen has been reached:
                } else if (healthPlayer.isAlive && !EndScreen.active)
                {
                    //Invoke ResumeGame Method
                    ResumeGame();
                }
                break;
        }
    }

    void PauzeGame()
    {
        // Pauses game
        Time.timeScale = 0;
        // Stops the audio
        AudioListener.pause = true;
    }

    void ResumeGame()
    {
        // Resumes game
        Time.timeScale = 1;
        // Resumes the audio
        AudioListener.pause = false;
    }
}
