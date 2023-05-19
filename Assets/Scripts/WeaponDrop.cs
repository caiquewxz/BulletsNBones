using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponDrop : MonoBehaviour
{
    public GameObject template;
    public int dropMinChanceValue;
    public int dropMaxChanceValue;

    void OnDestroy()
    {
        int dropChance = Random.Range(dropMinChanceValue, dropMaxChanceValue);
        if (dropChance > (dropMinChanceValue / dropMaxChanceValue))
        {
            GameObject newPlayerWeapon = Instantiate(template, transform.position, transform.rotation);
        }
    }
}