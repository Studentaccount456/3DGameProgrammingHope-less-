using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestart : MonoBehaviour
{
    public string mLevelToLoad;
    // load level again for game over screen
    public void LoadLevel()
    {
        SceneManager.LoadScene(mLevelToLoad);
    }
}
