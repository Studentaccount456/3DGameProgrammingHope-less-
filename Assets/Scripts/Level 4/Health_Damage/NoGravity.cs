using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoGravity : MonoBehaviour
{
    // Reference to PlayerMovement script
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        // Grabs the gravity variable of playerMovement script and sets it to 0:
        if (playerMovement != null) playerMovement.gravity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
