using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{

    private static EnemyController _instance;

    [SerializeField]
    HpComponent hpComponent;
    GameObject waveSystem;
    
    void Start()
    {
        waveSystem = GameObject.FindGameObjectWithTag("WaveSystem");

        hpComponent = GetComponent<HpComponent>();
        
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
        waveSystem.GetComponent<WaveSystem>();
        if(waveSystem.GetComponent<WaveSystem>().kills >= waveSystem.GetComponent<WaveSystem>().EnemiesThisWave())
        {
            Destroy(gameObject);
            waveSystem.GetComponent<WaveSystem>().kills++;
            waveSystem.GetComponent<WaveSystem>().StartWave();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
