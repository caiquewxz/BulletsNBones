using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HpComponent : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    public bool isEnemy;
    public bool isPlayer;

    [SerializeField] Text debugHP;

    public UnityEvent onDie;

    void Start()
    {
        currentHP = maxHP;

        if (isEnemy)
        {
            onDie.AddListener(WaveSystem.GetInstance().OnEnemyDie);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        debugHP.text = "HP: " + currentHP.ToString();

        if (currentHP <= 0)
        {
            onDie?.Invoke();
        }
    }
}
