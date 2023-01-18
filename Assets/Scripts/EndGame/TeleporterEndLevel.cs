using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterEndLevel : MonoBehaviour
{
    // Allows to drag in the Endscreen Canvas
    public GameObject EndScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // On Trigger effect:
    private void OnTriggerEnter(Collider other)
    {
        // If the Tag of the other object is Player:
        if (other.tag == "Player")
            // Put Canvas of the endscren on active:
            EndScreen.SetActive(true);
        // After 1 second (float) Invoke the method Endgame (The delay is added otherwise the Endscreen didn't come up)
        Invoke("EndGame", 1);
    }

    // Method EndGame
    void EndGame()
    {
        // Stop Time for the objects that rely on it (Here: Moving wall, ...)
        Time.timeScale = 0;
        // Stop the audio in the Game
        AudioListener.pause = true;
        // Unlocks the mouse cursor so you're able to press the buttons of the Endscreen
        Cursor.lockState = CursorLockMode.None;
    }
}
