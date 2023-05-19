using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackCooldown = 2f;
    public int attackDamage = 10;
    private float attackTimer;
    private GameObject player;

    void Start()
    {
        attackTimer = attackCooldown;
    }

    void Update()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackCooldown && player != null)
        {
            player.GetComponent<HpComponent>().TakeDamage(attackDamage);
            Debug.Log("Atual player HP: " + player.GetComponent<HpComponent>().currentHP);
            attackTimer = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && attackTimer >= attackCooldown)
        {
            //salva player
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //remover o player da variável
            player = null;
        }
    }

}
