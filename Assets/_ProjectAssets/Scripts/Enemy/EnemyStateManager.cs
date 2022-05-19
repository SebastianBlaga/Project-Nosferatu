using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    private static EnemyStateManager instance;
    public static EnemyStateManager Instance => instance;

    private void Awake()
    {
        SingletonlInitialization();
    }
    private void SingletonlInitialization()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
