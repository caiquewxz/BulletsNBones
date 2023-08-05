using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{

    private static EnemyController _instance;

    [SerializeField]
    HpComponent hpComponent;
    WaveSystem waveSystem;
    
    void Start()
    {
        waveSystem = GetComponent<WaveSystem>();
        
        if (hpComponent == null)
        {
            hpComponent = GetComponent<HpComponent>(); 
        }

        hpComponent?.onDie.AddListener(EnemyDie);
    }

    public static EnemyController GetInstance()
    {
        if (_instance)
        {
            return _instance;
        }
        else
        {
            _instance = FindObjectOfType<EnemyController>();
        }

        return _instance;
    }

    public void EnemyDie()
    {
        if(waveSystem.kills >= waveSystem.EnemiesThisWave())
        {
            Destroy(gameObject);
            waveSystem.kills++;
            waveSystem.StartWave();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
