using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonNW<T> : NetworkBehaviour where T :  NetworkBehaviour
{
    protected static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                var buffer = FindObjectsOfType<T>();
                if (buffer.Length > 1)
                {
                    Debug.LogWarning($"[{typeof(T)}] There are more than one instance in scene, are have been deleted.");
                    instance = buffer[0];
                }
                else
                    instance = FindObjectOfType<T>();

                if (instance == null)
                    Debug.LogError($"Instance of type {typeof(T)} not found. Make sure it's on the scene.");
            }
            return instance;
        }
    }
}
