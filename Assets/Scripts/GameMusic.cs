﻿using UnityEngine;
using System.Collections;

public class GameMusic : MonoBehaviour
{
    private static GameMusic instance = null;
    public static GameMusic Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
