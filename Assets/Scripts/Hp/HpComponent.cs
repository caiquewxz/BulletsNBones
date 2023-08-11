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
    public bool isPlayerDead;
    public GameObject particlePrefab;
    public GameObject player;
    public GameObject playerInstance;
    public CameraShake cameraShake;
    private GameObject bloodInstance;

    [SerializeField] Text debugHP;
    [SerializeField] float cameraShakeDuration;
    [SerializeField] float cameraShakeMagnitude;

    public UnityEvent onDie;
    public UnityEvent onTakeDamage;

    private void Update()
    {
        if (debugHP != null)
        {
            debugHP.text = "HP: " + currentHP.ToString();
        }
    }

    void Start()
    {
        playerInstance = GameObject.FindGameObjectWithTag("Player");

        currentHP = maxHP;
        isPlayerDead = false;

        if (isEnemy)
        {
            onDie.AddListener(WaveSystem.GetInstance().OnEnemyDie);
            //onDie.AddListener(EnemyController.GetInstance().EnemyDie);
            
        }

        bloodInstance = GameObject.FindGameObjectWithTag("PlayerDamageBlood");
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        

        if(cameraShake != null && currentHP > 0)
        {
            StartCoroutine(InstantiateBlood());
            StartCoroutine(cameraShake.Shake(cameraShakeDuration, cameraShakeMagnitude));
        }

        if (currentHP <= 0)
        {
            onDie?.Invoke();
        }
        else
        {
            onTakeDamage?.Invoke();
        }
    }

    private IEnumerator InstantiateBlood()
    {
        Instantiate(particlePrefab, player.transform);
        yield return new WaitForSeconds(1);
        Destroy(bloodInstance);
    }
}
