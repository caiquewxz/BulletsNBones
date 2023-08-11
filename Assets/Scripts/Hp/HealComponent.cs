using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealComponent : MonoBehaviour
{
    [SerializeField] int hpToHeal;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Heal()
    {
        player.GetComponent<HpComponent>().currentHP = player.GetComponent<HpComponent>().currentHP + hpToHeal;
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Heal();
            Destroy(gameObject);
        }
    }
}
