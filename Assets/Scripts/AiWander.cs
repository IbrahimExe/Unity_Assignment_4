using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class AiWander : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    public List<Transform> waypoints;
    private int currentWaypoint = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.remainingDistance == 0)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
            navMeshAgent.SetDestination(waypoints[currentWaypoint].position);
        }
    }
}
