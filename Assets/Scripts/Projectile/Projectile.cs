using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int bulletDamage = 10;
    public float timeToDestroyProjectile;
    public float launchForce;
    public AudioClip bulletSound;
    [SerializeField] float volume;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * launchForce, ForceMode.Impulse);
        Destroy(gameObject, timeToDestroyProjectile);
        AudioSource.PlayClipAtPoint(bulletSound, transform.position, volume);
    }

    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject.CompareTag("Enemy")) 
        {
            enemy?.gameObject.GetComponent<HpComponent>()?.TakeDamage(bulletDamage);
            Debug.Log("atual Enemy HP: " + enemy.gameObject.GetComponent<HpComponent>().currentHP);
            Destroy(this.gameObject);
        }
    }
}