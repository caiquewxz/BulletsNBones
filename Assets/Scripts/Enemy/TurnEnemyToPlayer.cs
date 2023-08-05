using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEnemyToPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject player;
    public float rotationSpeed = 5f;
    private EnemyAttack enemyAttack;

    private void Start()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        player = GameObject.FindGameObjectWithTag("PlayerModel");
        playerTransform = player.transform;

    }

    void Update()
    {
        if(enemyAttack.isAttacking == true)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            direction.y = 0f;

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime); 
        }
    }
}
