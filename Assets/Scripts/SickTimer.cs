using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//credit to https://www.youtube.com/watch?v=1hsppNzx7_0&ab_channel=CodeMonkey
public class SickTimer 
{
    // create function for timers
    public static SickTimer Create(Action action, float timer)
    {
        SickTimer sickTimer = new SickTimer(action, timer);

        GameObject gameObject = new GameObject("SickTimer", typeof(MonoBehaviourHook));
        gameObject.GetComponent<MonoBehaviourHook>().onUpdate = sickTimer.Update;

        return sickTimer;
    }

    //Dummy class to have acces to MonoBehaviour functions
    private class MonoBehaviourHook : MonoBehaviour {
        public Action onUpdate;
        private void Update()
        {
            if (onUpdate != null) onUpdate();
        }
    }
    
    // configurable action
    private Action action;
    // time for end of timer
    private float timer;
    private bool isDestroyed;

    // filling sicktimer
    private SickTimer (Action action, float timer)
    {
        this.action = action;
        this.timer = timer;
        isDestroyed = false;
    }

    // updates ticks on the timer and knows when to stop counting
    public void Update()
    {
        if (!isDestroyed)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                action();
                DestroySelf();
            }
        }
    }
    private void DestroySelf()
    {
        isDestroyed = true;
    }
}
