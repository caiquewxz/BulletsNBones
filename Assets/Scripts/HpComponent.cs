using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpComponent : MonoBehaviour
{
    public int maxHP;
    public int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        if(currentHP <= 0)
        { 
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
    }
}
