using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorMove : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField]
    float playerSpeed = 5f;
    [SerializeField]
    float rotationSpeed = 100f;
    
    void Start()
    {
        this.controller = this.GetComponent<CharacterController>();
    }


    void Update()
    {
        //movement and rotation with the use of vectors
        Vector3 movement = new Vector3();

        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            movement.z = 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            movement.z = -1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            transform.Rotate(Vector3.up, -1f * this.rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            transform.Rotate(Vector3.up, this.rotationSpeed * Time.deltaTime);
        }
        // makes the local location the global location
        this.controller.Move(transform.TransformDirection(movement.normalized) * this.playerSpeed * Time.deltaTime);

    }
}
