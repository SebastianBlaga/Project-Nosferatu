using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] points;
    private int destPoint=0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        GoToNextPoints();
    }

    private void GoToNextPoints()
    {
        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    private void Update()
    {
        Debug.Log(agent.destination);
        if (agent.remainingDistance < 0.5f)
            GoToNextPoints();
    }
}
