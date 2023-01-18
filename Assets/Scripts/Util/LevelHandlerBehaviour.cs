using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandlerBehaviour : MonoBehaviour
{
    public static void GoToRaw(string scene)
    {
        LoadScene(scene);
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
