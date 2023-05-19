using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HpComponent : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    public bool isEnemy;

    public UnityEvent onDie;

    void Start()
    {
        currentHP = maxHP;

        if (isEnemy)
        {
            onDie.AddListener(WaveSystem.GetInstance().OnEnemyDie);
        }
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

        if(currentHP <= 0)
        {
            onDie?.Invoke();
        }
    }
}
