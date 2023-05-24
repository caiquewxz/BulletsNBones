using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveSystem : MonoBehaviour
{
    public int wave;
    public int kills;
    public int remainingEnemiesAlive;
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
        remainingEnemiesAlive--;
        if(kills > EnemiesThisWave())
        {
            StartWave();
        }
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
    }

    private void StartWave()
    {
        wave++;
        enemiesToSpawn = EnemiesThisWave();

    }

    public int EnemiesThisWave()
    {
        return waveEnemies * wave;
    }
}


