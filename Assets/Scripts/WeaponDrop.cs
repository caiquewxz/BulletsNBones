using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponDrop : MonoBehaviour
{
    public GameObject template;
    public float dropChanceValue;
    private float dropChance;

    void OnDestroy()
    {
        dropChanceValue = dropChanceValue / 100;
        Debug.Log(dropChanceValue);
        dropChance = UnityEngine.Random.Range(0f, 1f);
        Debug.Log(dropChance);
        if (dropChanceValue > dropChance)
        {
            GameObject newPlayerWeapon = Instantiate(template, transform.position, transform.rotation);
        }
    }
}