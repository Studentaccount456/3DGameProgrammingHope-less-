using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevelLoader : MonoBehaviour
{
    public string mLevelToLoad;

    public void LoadLevel()
    {
        // Load the new level (mLevelLoad)
        SceneManager.LoadScene(mLevelToLoad);

    }
}
