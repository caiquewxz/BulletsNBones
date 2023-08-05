using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;

public class GameOver : MonoBehaviour
{
    HpComponent hpComponent;
    GameObject ammoText;
    GameObject fireModeText;
    GameObject hpText;
    [SerializeField] GameObject gameoverScreen;

    private void Start()
    {
        hpComponent = GetComponent<HpComponent>();
        ammoText = GameObject.FindGameObjectWithTag("AmmoText");
        fireModeText = GameObject.FindGameObjectWithTag("FireModeText");
        hpText = GameObject.FindGameObjectWithTag("AmmoText");

    }
    private void Update()
    {
        if (hpComponent.isPlayerDead)
        {
            
            Debug.Log(gameoverScreen);

            ammoText.SetActive(false);
            fireModeText.SetActive(false);
            hpText.SetActive(false);
            //gameoverScreen.SetActive(true);


            if (gameoverScreen)
            {
                Instantiate(gameoverScreen);
            }

            Destroy(this);
        }
        
    }

    void SetEnemiesToPatrol()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            EnemyPatrol enemyPatrol = enemy.GetComponent<EnemyPatrol>();
            EnemyNavigation enemyNavigation = enemy.GetComponent<EnemyNavigation>();

            if(enemyPatrol != null)
            {
                enemyPatrol.patrol = true;
            }
        }
    }
}
