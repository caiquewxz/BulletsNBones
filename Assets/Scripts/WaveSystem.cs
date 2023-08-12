using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] GameObject curePrefab;
 
    public int wave;
    public int kills;
    public int waveEnemies = 5;
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
        if (kills >= EnemiesThisWave())
        {
            InstantiateCureInRandomPosition();
            StartWave();
        }
        Debug.Log("enemy died!");
    }

    public void InstantiateCureInRandomPosition()
    {
        NavMeshHit hit;
        Vector3 randomPosition;

        if (NavMesh.SamplePosition(transform.position + Random.insideUnitSphere * 10f, out hit, 9999.0f, NavMesh.AllAreas))
        {
            randomPosition = hit.position;
            Instantiate(curePrefab, randomPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Nao foi possivel achar uma posição valida no navmesh");
        }
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

    public void StartWave()
    {
        kills = 0;
        wave++;
        enemiesToSpawn = EnemiesThisWave();
        Debug.Log(EnemiesThisWave());

    }

    public int EnemiesThisWave()
    {
        return waveEnemies * wave;
    }
}