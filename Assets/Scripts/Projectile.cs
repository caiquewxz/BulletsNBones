using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int bulletDamage = 10;
    public float timeToDestroyProjectile;
    public GameObject projectile;
    public GameObject character;
    public float launchForce;

    public void CreateBullet()
    {
        GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        Vector3 direction = character.transform.forward;
        newProjectile.GetComponent<Rigidbody>().AddForce(direction * launchForce, ForceMode.Impulse);
        Destroy(newProjectile, timeToDestroyProjectile);
    }

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