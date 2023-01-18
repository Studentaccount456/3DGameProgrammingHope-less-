using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    //The mouse sensitivity with a default 100RPM which is changable in the inspector
    public float mouseSensitivity = 100f;
    //The player object
    public Transform playerBody;

    //Used to determine the mouse position
    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //The mouse is locked in the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Uses the xy-axises, and multiplies them with the mouse-sensitivity
        //according to the time passed to determine the mouse coordinates  
        float MouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Limits the mouse Y-coordinates to not go over -90 and 90 degrees
        //which will let the player turn the camera upside-down
        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotates the camera according to the coordinates calculated above
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * MouseX);
    }
}