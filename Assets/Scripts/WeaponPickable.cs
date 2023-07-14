using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickable : MonoBehaviour
{
    public GameObject template;
    private GameObject player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !!player)
        {
            GameObject[] weapons = GameObject.FindGameObjectsWithTag("Weapon");

            foreach(GameObject weapon in weapons)
            {
                Destroy(weapon);
            }

            InstantiateNewWeapon();
            
            //newPlayerWeapon.transform.parent = GameObject.FindGameObjectWithTag("PlayerModel").transform;>
            Destroy(gameObject);
        }
    }

    private void InstantiateNewWeapon()
    {
        GameObject weaponInstance = Instantiate(template);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            player = collider.gameObject;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            player = null;
        }
    }
}
