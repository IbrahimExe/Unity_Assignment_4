using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

// Ctrl + r + r : Allows multiple variables using the same name to be renamed.

public class AiAgent : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    public Transform chaseTarget;
    public List<Transform> waypoints;

    private int currentWaypoint = 0;

    private AIState aiState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
        aiState = AIState.Patrol;
    }

    // Update is called once per frame
    void Update()
    {
        // navMeshAgent.SetDestination(chaseTarget.position);

        if (aiState == AIState.Patrol)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
                navMeshAgent.SetDestination(waypoints[currentWaypoint].position);
            }
        }

        else if (aiState == AIState.Chase)
        {
            navMeshAgent.SetDestination(chaseTarget.position);

            if (Vector3.Distance(transform.position, chaseTarget.position) > (float) 15)
            {
                aiState = AIState.Patrol;

                navMeshAgent.SetDestination(waypoints[currentWaypoint].position);
            }
        }

        else if (aiState == AIState.Investigate)
        {
            navMeshAgent.SetDestination(transform.position);
        }

        // When chaseTarget is reached, Move to next one.
        
    }

    public void PlayerSpotted(Transform playerTarget)
    {
        chaseTarget = playerTarget;
        navMeshAgent.SetDestination(chaseTarget.position);
        aiState = AIState.Chase;
    }

    public void StartInvestigate()
    {
        aiState = AIState.Investigate;
    }
    public void EndInvestigate()
    {
        if (aiState == AIState.Investigate)
        {
            aiState = AIState.Patrol;
        }
    }

}

public enum AIState
{
    Patrol,
    Chase,
    Investigate
}
