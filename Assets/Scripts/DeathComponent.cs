using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(HpComponent))]
public class DeathComponent : MonoBehaviour
{
    HpComponent hpComponent;
    [SerializeField] Animator playerAnimator;
    [SerializeField] List<MonoBehaviour> objectsToDisableWhenDie;
    void Start()
    {
        hpComponent = GetComponent<HpComponent>();
        

        hpComponent?.onDie.AddListener(OnDie);
    }

    void OnDie()
    {
        Debug.Log("Morri " + playerAnimator?.name);
        playerAnimator?.SetBool("IsDead?", true);
        
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
