using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(HpComponent))]
public class DeathComponent : MonoBehaviour
{
    GameOver gameOver;
    HpComponent hpComponent;
    [SerializeField] Animator playerAnimator;
    [SerializeField] List<MonoBehaviour> objectsToDisableWhenDie;
    void Start()
    {
        hpComponent = GetComponent<HpComponent>();
        gameOver = GetComponent<GameOver>();

        hpComponent?.onDie.AddListener(OnDie);
    }

    void OnDie()
    {
        Debug.Log("Morri " + playerAnimator?.name);
        playerAnimator?.SetBool("IsDead?", true);
        hpComponent.isPlayerDead = true;
        if(hpComponent.isPlayerDead)
        {
            Debug.Log("dead");
        }
        
        foreach(var obj in objectsToDisableWhenDie)
        {
            obj.enabled = false;
        }

        Weapon[] weapons = FindObjectsOfType<Weapon>();

        foreach(Weapon weapon in weapons) 
        {
            Destroy(weapon.gameObject);
        }
    }
    
}
