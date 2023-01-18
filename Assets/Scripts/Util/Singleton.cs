using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                var singletons = SearchScene();
                if (singletons.Length > 0)
                {
                    _instance = singletons[0];
                } else
                {
                    GameObject singletonObject = new GameObject();
                    singletonObject.hideFlags = HideFlags.HideAndDontSave;
                    _instance = singletonObject.AddComponent<T>();
                }
            }

            return _instance;
        }
    }

    private static T[] SearchScene()
    {
        var objects = FindObjectOfType(typeof(T)) as T[];

        if (objects == null) return new T[0];

        if (objects.Length > 1)
        {
            Debug.LogWarning($"Found more than one {typeof(T)} in the scene.");
        }

        return objects;
    }
}
