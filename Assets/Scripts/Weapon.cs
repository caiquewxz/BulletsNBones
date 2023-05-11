using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    public float launchForce;
    public GameObject character;
    public float timeToDestroyProjectile;
    

    void Update()
    {
        //Clone the projectile and launch it every time the button Fire1 is pressed.
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector3 direction = character.transform.forward;
            newProjectile.GetComponent<Rigidbody>().AddForce(direction * launchForce, ForceMode.Impulse);
            Destroy(newProjectile, timeToDestroyProjectile);
        }
    }
}
