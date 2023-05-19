using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveSystem : MonoBehaviour
{
    public int wave;
    public int kills;
    private bool isWaveCompleted;
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
        Debug.Log("enemy died!");
    }


    void Start()
    {
        if(GetInstance() && _instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}
