using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugHandlerBehaviour : MonoBehaviour
{
    public static void SetTimeScale(int scale)
    {
        Time.timeScale = scale;
    }
}
