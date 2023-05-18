using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int bulletDamage = 10;
    public float timeToDestroyProjectile;
    public float launchForce;
    public AudioClip bulletSound;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * launchForce, ForceMode.Impulse);
        Destroy(gameObject, timeToDestroyProjectile);
        AudioSource.PlayClipAtPoint(bulletSound, transform.position);
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