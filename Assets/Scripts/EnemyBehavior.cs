using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyBehavior : MonoBehaviour
{
    public Transform patrol1, patrol2, patrol3;
    public Transform player;
    public NavMeshAgent agent;
    public float chaseDistance = 10f;
    public float attackDistance = 1.2f;

    private Transform[] patrolPoints;
    private int currentPatrolIndex;
    private State state;
    public int health = 100;
    public int damage = 33;
    public PlayerMovement playerMovement;
    private bool canDamage = true;
    public Animator enemyAni;
    public bool isDead = false;
    public AudioSource Sound;
   


    enum State
    {
        PATROL,
        CHASE,
    }

    void Start()
    {
        state = State.PATROL;
        patrolPoints = new Transform[] { patrol1, patrol2, patrol3 };
        currentPatrolIndex = 0;
        Patrol();

    }

    void Update()
    {
        if (isDead)
        {
            return;
        }
        switch (state)
        {
            case State.PATROL:
                Patrol();
                break;
            case State.CHASE:
                Chase();
                break;
        }

        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceToPlayer <= chaseDistance)
        {
            state = State.CHASE;
        }
        else
        {
            state = State.PATROL;
        }
    }

    void Patrol()
    {
        if (agent.remainingDistance < 0.5f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }

    void Chase()
    {
        agent.SetDestination(player.position);
        if (agent.remainingDistance < attackDistance)
        {
            if (canDamage)
            {
                Debug.Log("Player caught!");
                StartCoroutine(DamageDelay());
            }
        }


    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        print("Health: " + health);
        if (health <= 0)
        {
            Die();

        }
    }
    void Die()
    {
        isDead = true;
        agent.enabled = false;
        enemyAni.enabled = false;
        // play audio clip when enemy dies
        Sound.Play();
        Rigidbody[] ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.transform.gameObject.layer = LayerMask.NameToLayer("ragdoll");
        }
        GetComponent<Collider>().enabled = false;
        StopAllCoroutines();
    }
    IEnumerator DamageDelay()
    {
        canDamage = false;
        enemyAni.SetBool("isAttacking", true);
        Debug.Log("Player took damage");
        playerMovement.TakeDamage(damage);
        yield return new WaitForSeconds(1);
        enemyAni.SetBool("isAttacking", false);
        canDamage = true;

    }
    
    
}
