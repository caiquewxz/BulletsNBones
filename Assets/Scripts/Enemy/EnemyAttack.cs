using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackCooldown = 2f;
    public int attackDamage1 = 10;
    public int attackDamage2 = 15;
    public bool isAttacking;

    [SerializeField]
    private Animator animator;
    private float animationTimeAttack1 = 3f;
    private float animationTimeAttack2 = 3f;

    private GameObject player;
    private bool canAttack;

    HpComponent hpComponent;


    void Start()
    {
        animator = GetComponent<Animator>();
        hpComponent = GetComponent<HpComponent>();
    }

    IEnumerator RandomAttack()
    {
        bool isAttacking01 = Random.value >= .5f;
        isAttacking = true;

        if (isAttacking01)
        {
            animator.SetBool("Attacking1", true);
        }
        else
        {
            animator.SetBool("Attacking2", true);
        }
        yield return new WaitForSeconds(isAttacking ? animationTimeAttack1 : animationTimeAttack2);
        isAttacking = false;

        if (player)
        {
            yield return RandomAttack();
        }
    }

    public void TryDealDamage(int attackIndex)
    {
        if (!player)
        {
            return;
        }

        if(attackIndex == 0)
        {
            player.GetComponent<HpComponent>().TakeDamage(attackDamage1);
            animator.SetBool("Attacking1", false);

        }
        else
        {
            player.GetComponent<HpComponent>().TakeDamage(attackDamage2);
            animator.SetBool("Attacking2", false);
        }
    }

    void FinishAnimation()
    {

    }

    bool IsPlayer(Component other)
    {
        return other.CompareTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsPlayer(other) && hpComponent.isPlayerDead == false)
        {
            //salva player
            player = other.gameObject;
            StartCoroutine(RandomAttack());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsPlayer(other))
        {
            //remover o player da variável
            player = null;
        }
    }

}
