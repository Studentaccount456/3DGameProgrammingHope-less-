using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class Extensions
{
    public static bool find<T>(this T[] array, T target)
    {
        return array.Contains(target);
    }
}
public class MyGameManager : MonoBehaviour
{
    
    // array for all patient game objects
    private GameObject[] Patients;
    public GameObject mainCanavas;
    public GameObject gameOverCanavas;
    public GameObject endLevelCanavas;
    // configurable endtime
    [SerializeField]
    float endtime;
    
    public enum GameStates
    {
        Playing,
        GameOVer,
        EndLevel
    }
    //starting Gamestate
    public GameStates gameState = GameStates.Playing;

    void Start()
    {
        // fills patient array
        Patients = GameObject.FindGameObjectsWithTag("Patient");
        // makes SickTimer
        SickTimer.Create(End, endtime);      
    }

    // Update is called once per frame
    void Update()
    {
        // switches gamestates
        switch (gameState)
        {
            // ends level when timer runs out
            case GameStates.EndLevel:
                mainCanavas.SetActive(false);
                endLevelCanavas.SetActive(true);
                break;
            // game over screen after patient dies
            case GameStates.Playing:
                // searches in all patients
                foreach(var patient in Patients)
                {
                    // gets all animators and their info 
                    var animator = patient.GetComponent<Animator>();
                    // searches for dead of patient in animation
                    foreach (var clipInfo in animator.GetCurrentAnimatorClipInfo(0))
                    {
                        if (!clipInfo.clip.name.Equals("Dead")) return;
                        gameState = GameStates.GameOVer;
                        mainCanavas.SetActive(false);
                        gameOverCanavas.SetActive(true);
                    }
                }

                    break;

        }
        
    }
    private void End()
    {
        gameState = GameStates.EndLevel;
    }
}
