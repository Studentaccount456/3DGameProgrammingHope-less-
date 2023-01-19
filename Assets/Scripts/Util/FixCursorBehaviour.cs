using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCursorBehaviour : MonoBehaviour
{
    void Update()
    {
        if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
