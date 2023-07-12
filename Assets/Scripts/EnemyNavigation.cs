using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    EnemyAttack enemyAttack;
    Animator animator;
    Vector3 lastFramePosition;
    float speed;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("PlayerModel").transform;

        agent = GetComponent<NavMeshAgent>();
        enemyAttack = GetComponent<EnemyAttack>();
        animator = GetComponent<Animator>();
    }

    void CalcSpeed()
    {
        speed = (((transform.position - lastFramePosition).magnitude) / Time.deltaTime) / agent.speed;
    }
    void Update()
    {
        agent.SetDestination(enemyAttack.isAttacking ? transform.position : target.position);
        CalcSpeed();
        animator.SetFloat("SpeedNormalized", speed);
        lastFramePosition = transform.position;
    }
}
