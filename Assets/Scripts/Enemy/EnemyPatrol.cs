using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyPatrol : MonoBehaviour
{

    [SerializeField] NavMeshAgent agent;
    [SerializeField] float patrolDistance = 15;
    [SerializeField] float huntRange = 10;

    HpComponent playerHpComponent;
    EnemyAttack enemyAttack;
    Vector3 agentPosition;
    Vector3 playerPosition;
    Vector3 lastFramePosition;
    Animator animator;
    GameObject player;
    float distance;
    float speed;
    public bool patrol = true;
    public Transform target;

    EnemyNavigation enemyNavigation;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("PlayerModel").transform;
        enemyAttack = GetComponent<EnemyAttack>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            playerHpComponent = player.GetComponent<HpComponent>();
        }

        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }

        if (enemyAttack == null)
        {
            enemyAttack = GetComponent<EnemyAttack>();
        }

        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
     
        // O player não está morto?
        if(!playerHpComponent.isPlayerDead)
        {
            //estou perto o suficiente do jogador?
            if (CalcDistanceBetweenPlayerAndEnemy() < huntRange)
            {
                patrol = false;
                HuntPlayer();
            }
            //estou longe do player, devo patrulhar se estiver em idle
            else
            {
                CheckForIdleAndPatrol();
            }
        }
        //o player está morto, devo patrulhar se estiver em idle
        else
        {
            CheckForIdleAndPatrol();
        }
       
    }

    void CheckForIdleAndPatrol()
    {
        if (patrol && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToRandomSpot();
        }
    }

    void HuntPlayer()
    {
        agent.SetDestination(enemyAttack.isAttacking ? agent.transform.position : target.transform.position);
        CalcSpeed();
        animator.SetFloat("SpeedNormalized", speed);
        lastFramePosition = agent.transform.position;
        patrol = true;
    }

    void GoToRandomSpot()
    {
        patrol = true;
        Vector3 randomPosition = GetRandomPosition();
        agent.SetDestination(randomPosition);
    }

    void CalcSpeed()
    {
        speed = (((transform.position - lastFramePosition).magnitude) / Time.deltaTime) / agent.speed;
    }

    private float CalcDistanceBetweenPlayerAndEnemy()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        playerPosition = player.transform.position;
        agentPosition = agent.transform.position;
        distance = (playerPosition - agentPosition).magnitude;

        return distance;
    }

    float CheckIfPlayerIsInTheRange()
    {
        float result = Vector3.Distance(agent.transform.position, player.transform.position);

        if (result >= huntRange)
        {
            Debug.Log("The Player is not in the range");
        }
        else
        {
            Debug.Log("The Player is not in the range");
        }

        return result;
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolDistance;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection + transform.position, out hit, patrolDistance, 1);
        return hit.position;
    }
}
