using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Code in collaberation with Marius
    // To assign characterController component
    public CharacterController controller;

    // speed of player
    public float speed = 12f;
    // Gravity simulation variable
    public float gravity = -9.81f;
    // Jump height
    public float jump = 1f;

    // Object put on bottom of character to determine if character is standing on the ground or not:
    public Transform groundCheck;
    // Distance from ground => To ensure object doesn't get stuck in it.
    public float groundDistance = 0.4f;
    // Variable to assign ground to:
    public LayerMask groundMask;

    Vector3 velocity;
    // Is object on ground or not checker:
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        // Is the object on the ground checker:
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Gets the input on the X-axis and Y-axis (WASD or arrows):
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Updates the position according to input:
        Vector3 move = transform.right * x + transform.forward * z;

        // Moves object according to the position which is calculated in move:
        controller.Move(move * speed * Time.deltaTime);

        // If player presses space the player will jump:
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
