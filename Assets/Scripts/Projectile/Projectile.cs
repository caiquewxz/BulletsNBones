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
    [SerializeField] GameObject hitPartice;

    private void Start()
    {
        if (hitPartice == null) 
        {
            Debug.LogError("Please, set an a hit particle.");
        }

        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * launchForce, ForceMode.Impulse);
        Destroy(gameObject, timeToDestroyProjectile);
        AudioSource.PlayClipAtPoint(bulletSound, transform.position, volume);
    }

    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject.CompareTag("Enemy")) 
        {
            if(hitPartice != null)
            {
                Instantiate(hitPartice, enemy.transform.position, transform.rotation);
            }

            enemy?.gameObject.GetComponent<HpComponent>()?.TakeDamage(bulletDamage);
            Debug.Log("atual Enemy HP: " + enemy.gameObject.GetComponent<HpComponent>().currentHP);
            Destroy(this.gameObject);
        }
    }
}