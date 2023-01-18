using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //Used to assign the CharcterController component of the object that will be affected by the script
    public CharacterController controller;

    //Properties that can be assigned in the inspector of unity but have default values just in case
    //The speed movement of the object
    public float speed = 12f;
    //The amount of gravity that will be upon object if he's not on the ground
    public float gravity = -9.81f;
    //The jump height
    public float jump = 1f;

    //A cube oject that will be put below the main object to determine if the object is on the ground
    public Transform groundCheck;
    //The distance from the ground so that the object doesn't get stuck in it
    public float groundDistance = 0.4f;
    //The layer that will be used as 'ground'
    public LayerMask groundMask;


    Vector3 velocity;
    //Will be used to check if the object is on the ground layer
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //Checks if the object is on the ground according to the groundCheckObject, the radius and the layer which is marked as the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Gets the arrow or wsad-input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Updates the position according to which input is pressed
        Vector3 move = transform.right * x + transform.forward * z;

        //Moves the object according to position calculated above
        controller.Move(move * speed * Time.deltaTime);

        //If the player presses the Space-button the player will be moved in the air
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}