using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int bulletDamage = 10;
    private GameObject projectile;

    private void OnTriggerEnter(Collider bullet)
    {
        if (bullet.gameObject.CompareTag("Enemy"))
        {
            bullet.gameObject.GetComponent<HpComponent>().TakeDamage(bulletDamage);
            Debug.Log("atual Enemy HP: " + bullet.gameObject.GetComponent<HpComponent>().currentHP);
            Destroy(this.gameObject);
        }
    }
}