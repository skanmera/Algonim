﻿using UnityEngine;


public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    protected static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                if (instance == null)
                    Debug.LogWarning(typeof(T) + "is nothing");
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        EnsureInstance();
    }

    protected virtual void Start() { }
    protected virtual void Update() { }
    protected virtual void OnPostRender() { }
    protected virtual void OnRenderObject() { }

    protected bool EnsureInstance()
    {
        if (instance == null)
        {
            instance = (T)this;
            return true;
        }
        else if (Instance == this)
        {
            return true;
        }

        Destroy(this);
        return false;
    }
}
