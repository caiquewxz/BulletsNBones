using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponDrop : MonoBehaviour
{
    public GameObject template;
    public float dropChanceValue;

    void OnDestroy()
    {
        dropChanceValue = dropChanceValue / 100;
        int dropChance = (int)RandomRange(0f, 1f);
        if (dropChance > dropChanceValue)
        {
            GameObject newPlayerWeapon = Instantiate(template, transform.position, transform.rotation);
        }
    }

    private int RandomRange(float v1, float v2)
    {
        throw new NotImplementedException();
    }
}