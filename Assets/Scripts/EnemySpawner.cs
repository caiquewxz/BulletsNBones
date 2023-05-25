using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnInterval;
    private int spawnedEnemies;
    private float timer;
    private Transform characterTransform;

    public WaveSystem waveSystemReference;

    private void Start()
    {
        characterTransform = transform.Find("Prefab_SkeletonEnemy");
    }

    void Update()
    {
        StartCoroutine(SpawnEnemies());
    }

    public IEnumerator SpawnEnemies()
    {
        if(waveSystemReference.enemiesToSpawn > 0)
        {

            timer += Time.deltaTime;

            yield return new WaitForSeconds(spawnInterval);

            if (timer >= spawnInterval)
            {
                GameObject clone = Instantiate(enemy, transform.position, transform.rotation);
                
                if(waveSystemReference.enemiesToSpawn > 0)
                {
                    waveSystemReference.enemiesToSpawn--;
                }
                timer = 0f;
            }
        }
    }
}