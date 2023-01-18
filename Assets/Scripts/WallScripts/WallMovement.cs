using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    // Movespeed variable for a standard amount of movespeed if none is given: 
    public static int movespeed = 1;
    // Allows to modify the direction for the object to move:
    public Vector3 userDirection = Vector3.forward;
    // Variable to determine how fast the wall moves:
    public int speed = movespeed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Wait in case the game is paused.
        if (PauseHandlerBehaviour.IsPaused) return;
        // Use the Translate function of transform to move wall
        // userdirection => Direction to go
        // speed => How fast
        // Time.deltaTime => To accomodate for fps
        transform.Translate(userDirection * speed * Time.deltaTime);
    }
}
