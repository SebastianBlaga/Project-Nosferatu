using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class FamilyMember : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public Animator humanAnimator;
    public float distance = 0.1f;
    private bool isSafeZoonClose = false;
    private Vector3 agentDestination;

    private bool isPlayerClose = false;

    private static FamilyMember instance;
    public static FamilyMember Instance => instance;

    public float health = 100f;

    public float detectRadius = 2f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        humanAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isPlayerClose && !isSafeZoonClose)
        {
            agent.SetDestination(player.position);
            humanAnimator.SetBool("isRunning", true);
        }
        else if (isSafeZoonClose && isPlayerClose)
        {
            agent.SetDestination(new Vector3(54.616f, 1, 129.159f));

        }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            humanAnimator.SetBool("isRunning", false);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerClose = true;
            agentDestination = player.position;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destination"))
        {
            isSafeZoonClose = true;
            agentDestination = new Vector3(54.616f, 1, 129.159f);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}


