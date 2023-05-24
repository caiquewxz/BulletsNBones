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

    IEnumerator SpawnEnemies()
    {
        if(waveSystemReference.enemiesToSpawn > 0)
        {
            
            yield return new WaitForSeconds(spawnInterval);

            timer += Time.deltaTime;

            if (timer >= spawnInterval)
            {
                timer = 0f;
                GameObject clone = Instantiate(enemy, transform.position, transform.rotation);
                waveSystemReference.enemiesToSpawn--;
            }
        }
    }
}
