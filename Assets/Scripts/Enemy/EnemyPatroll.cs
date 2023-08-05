using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatroll : MonoBehaviour
{

    [SerializeField] NavMeshAgent agent;
    [SerializeField] float patrolDistance = 15;

    public bool patrol = true;
    // Start is called before the first frame update
    void Start()
    {
        if(agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (patrol && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToRandomSpot();
        }
    }

    void GoToRandomSpot()
    {
        Vector3 randomPosition = GetRandomPosition();
        agent.SetDestination(randomPosition);
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolDistance;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection + transform.position, out hit, patrolDistance, 1);
        return hit.position;
    }
}
