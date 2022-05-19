using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager instance;
    public static EnemyManager Instance => instance;

    public enum EnemyState
    {
        Patrol,
        Idle,
        Attack,
        Chase,
        Dead
    }

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
