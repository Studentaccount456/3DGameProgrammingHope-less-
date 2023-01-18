using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandlerBehaviour : MonoBehaviour
{
    public static void GoToLevel(string level)
    {
        LoadScene("Scenes/Level " + level);
    }

    public static void GoToMainMenu()
    {
        LoadScene("Scenes/MainMenu");
    }

    private static void LoadScene(string scene)
    {
        Debug.Log($"Switching to scene {scene}");
        SceneManager.LoadScene(scene);
    }
}
