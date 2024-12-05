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
        // two states, patrol and chase.
        PATROL,
        CHASE,
    }

    void Start()
    {
        // start state is patrol, and the patrol points are set
        state = State.PATROL;
        patrolPoints = new Transform[] { patrol1, patrol2, patrol3 };
        currentPatrolIndex = 0;
        Patrol();

    }

    void Update()
    {
        // if it dies, return out 
        if (isDead)
        {
            return;
        }
        // switch statement to choose the state of enemy
        switch (state)
        {
            // if the state is patrol, call the patrol method
            case State.PATROL:
                Patrol();
                break;
            // if the state is chase, call the chase method
            case State.CHASE:
                Chase();
                break;
        }
        // check the distance between the player and the enemy
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        // if the distance is less than the chase distance, the state is set to chase
        if (distanceToPlayer <= chaseDistance)
        {
            state = State.CHASE;
        }
        //and if not, the state is set to patrol
        else
        {
            state = State.PATROL;
        }
    }

    void Patrol()
    {
        // if the agent is close to the patrol point, move set the patrol
        // index to the next and set new destination to that point
        if (agent.remainingDistance < 0.5f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }

    void Chase()
    {
        // set the destination to the player position
        agent.SetDestination(player.position);
        // if the agent is close to the player, the enemy attack

        if (agent.remainingDistance < attackDistance)
        {
            // if bool is true, the player takes damage
            if (canDamage)
            {
                Debug.Log("Player caught!");
                StartCoroutine(DamageDelay());
            }
        }


    }
    // enemy take damage method
    public void TakeDamage(int damage)
    {
        // health is reduced by the damage amount
        health -= damage;
        print("Health: " + health);
        // and if health is less than or equal to 0 run death method
        if (health <= 0)
        {
            Die();

        }
    }
    void Die()
    {
        // set isDead to true, disable the agent and the animator
        isDead = true;
        agent.enabled = false;
        enemyAni.enabled = false;
        // play audio clip when enemy dies
        Sound.Play();
        // set the layer of the enemy to ragdoll
        Rigidbody[] ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.transform.gameObject.layer = LayerMask.NameToLayer("ragdoll");
        }
        // disable the collider and stop all coroutines assosiated with the enemy
        GetComponent<Collider>().enabled = false;
        StopAllCoroutines();
    }
    IEnumerator DamageDelay()
    {
        // if the bool is true, the player takes damage and the bool is set to false
        canDamage = false;
        enemyAni.SetBool("isAttacking", true);
        Debug.Log("Player is attacked");
        // run take damage method from player movement script
        playerMovement.TakeDamage(damage);
        yield return new WaitForSeconds(1);
        enemyAni.SetBool("isAttacking", false);
        canDamage = true;

    }
    
    
}
