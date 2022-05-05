using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public Animator enemyAnimator;
    public CharacterController enemyController;
    public float attack_Distance = 3f;

    public float detectRadius = 10f;


    public float health = 100f;
    
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        // Vector3 playerPosition = player.transform.position * -3f;
        // agent.destination = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= detectRadius)
        {
            agent.SetDestination(player.position +  new Vector3(-10,0,0));
        }

    }
    
    public void TakeDamage (float amount, bool effect)
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
