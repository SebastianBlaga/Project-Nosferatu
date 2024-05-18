using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public Animator enemyAnimator;
    public CharacterController enemyController;
    public float attack_Distance = 3f;
    public Transform[] points;
    private int destPoint = 0;

    public float detectRadius = 10f;
    public float health = 100f;


    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyAnimator.Play("Rise");
        }

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= detectRadius)
        {
            StartChase();
        }

        if (distance <= attack_Distance)
        {
            enemyAnimator.SetBool("isAttacking", true);

        }
        else
        {
            enemyAnimator.SetBool("isAttacking", false);

        }
        if (agent.remainingDistance < 0.5f)
            GoToNextPoints();
        // agent.velocity = enemyController.velocity;
    }

    private void StartChase()
    {
        agent.speed = 4f;
        agent.stoppingDistance = 3f;
        agent.SetDestination(player.position);
        enemyAnimator.SetBool("isRunning", true);
    }

    private void GoToNextPoints()
    {
        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    public void TakeDamage(float amount, bool effect)
    {
        health -= amount;
        if (effect == true)
        {
            Stun();
        }
        if (health <= 0f)
        {
            Die();
        }

    }
    void Die()
    {
        enemyAnimator.SetBool("isDead", true);
        gameObject.GetComponent<Enemy>().enabled = false;
    }
    void Stun()
    {
        enemyAnimator.SetBool("isIdle", true);
        //StartCoroutine(CoroutineMethod());

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }

    /*   IEnumerator CoroutineMethod()
       {
           yield return new WaitForSeconds(3);
       }
    */
}
