using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveSystem : MonoBehaviour
{
    public int wave;
    public int kills;
    public int waveEnemies;
    public int enemiesToSpawn;
    private static WaveSystem _instance;

    public UnityEvent onWaveCleared; 

    //singleton pattern
    public static  WaveSystem GetInstance()
    {
        if (_instance)
        {
            return _instance;
        }
        else
        {
            _instance = FindObjectOfType<WaveSystem>();
        }

        return _instance;
    }

    public void OnEnemyDie()
    {
        kills++;
        Debug.Log("enemy died!");
    }


    void Start()
    {
        if(GetInstance() && _instance != this)
        {
            Destroy(gameObject);
        }

        StartWave();
    }

    void Update()
    {
        if (kills > EnemiesThisWave())
        {
            StartWave();
        }
    }

    public void StartWave()
    {
        wave++;
        enemiesToSpawn = EnemiesThisWave();
    }

    public int EnemiesThisWave()
    {
        if(waveEnemies == 0)
        {
            return waveEnemies = 5;
        }
        else
        {
            return waveEnemies * wave;
        }
    }
}