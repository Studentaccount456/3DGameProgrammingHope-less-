using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandlerBehaviour : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject PauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            OnTogglePaused();
        }
        PauseMenu.SetActive(IsPaused);
    }

    public void OnTogglePaused()
    {
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0f : 1f;
    }
}
