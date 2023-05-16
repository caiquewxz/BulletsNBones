using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnCooldown;
    private float timer;
    private Transform characterTransform;

    private void Start()
    {
        characterTransform = transform.Find("Prefab_SkeletonEnemy");
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnCooldown)
        {
            timer = 0f;
            GameObject clone = Instantiate(enemy, transform.position, transform.rotation);
        }
    }
}
