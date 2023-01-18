using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Script is based on script in this video: https://youtu.be/_QajrabyTJc

    
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Puts the mouse cursor in Locked mode, which also makes mouse visually disappear:
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the input of the mouse on the X-axis:
      float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        // Gets the input of the mouse on the Y-axis:
      float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Limits the mouse Y-coördinates to not gove over 90° up and 90° down  => Otherwise heads snaps over natural limit (realism)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
