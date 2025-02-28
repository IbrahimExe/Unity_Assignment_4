using UnityEngine;
using UnityEngine.AI;

public class AiFollow : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform target;

    void Start()
    {
        
    }

    void Update()
    {
        navMeshAgent.SetDestination(target.position);
    }
}
