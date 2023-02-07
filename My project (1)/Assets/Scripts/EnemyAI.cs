using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent navAgent;
    Transform player;
    [SerializeField] LayerMask whatIsGround, whatIsPlayer;
    [SerializeField] bool retreatableEnemy;

    //Patrolling
    private Vector3 walkPoint;
    bool walkPointSet;
    [SerializeField] float walkPointRange;

    //Attacking
    [SerializeField] GameObject projectile;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    [SerializeField] float attackResetTime;
    [SerializeField] float attackForce;
    bool alreadyAttacked;

    //States
    [SerializeField] float sightRange;
    bool playerInSightRange, playerInAttackRange;

    public float knockbackForce;
    public float knockbackTime;
    public float knockbackCounter;





    private void Awake()
    {
        player = GameObject.Find("Character").transform;
        navAgent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        if (knockbackCounter <= 0)
        {
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (!playerInSightRange && !playerInAttackRange)
            {
                Patrolling();
            }
            if (playerInSightRange && !playerInAttackRange)
            {
                ChasePlayer();
            }
            if (playerInSightRange && playerInAttackRange)
            {
                AttackPlayer();
            }
        }
        else
        {
            alreadyAttacked = false;
            knockbackCounter -= Time.deltaTime;
        }
    }

    private void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        if (walkPointSet)
        {
            navAgent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        navAgent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        navAgent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, attackPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * attackForce, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), attackResetTime);
        }

        Vector3 timeToRetreat = transform.position - player.position;
        if (timeToRetreat.magnitude <= 10 && retreatableEnemy)
        {
            Retreat();
        }
    }

    private void Retreat()
    {
        navAgent.SetDestination(walkPoint);
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void Knockback(Vector3 direction)
    {
        knockbackCounter = knockbackTime;
    
        transform.position = direction * knockbackForce * Time.deltaTime;
    }


    private void OnDrawGizomsSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
