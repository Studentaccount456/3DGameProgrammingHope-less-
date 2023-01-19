using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRateBehaviour : MonoBehaviour
{
    void Start()
    {
        PauseHandlerBehaviour.IsPaused = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}
