using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float MaxHealth = 50.0f;

    //Patroling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    //public GameObject projectile;
    public ObjectPool ProjectilePool;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public State MachineState;

    private const int SightedFlag = 1;
    private const int AttackFlag = 2;
    private const int PatrolFlag = 4;
    private int Flags = 0;
    private float health;
    private Health enemyHealth;

    public enum State
    {
        Default = 0,
        Patrol = 4,
        Chase = 1,
        Attack = 2,
    }

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        MachineState = State.Default;
    }

    void OnEnable()
    {
        health = MaxHealth;
        Debug.Log("AI actived with " + health + " health");
        //agent.enabled = true;
        gameObject.AddComponent<Health>();
        enemyHealth = gameObject.GetComponent<Health>();
    }

    void OnDisable()
    {
        Destroy(gameObject.GetComponent<Health>());
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInSightRange)
            Flags |= SightedFlag;
        if (playerInAttackRange)
            Flags |= AttackFlag;
        if (Flags == 0)
            Flags |= PatrolFlag;

        switch(Flags)
        {
            case SightedFlag:
                MachineState = State.Chase;
                break;
            case AttackFlag:
            case SightedFlag | AttackFlag:
                MachineState = State.Attack;
                break;
            case PatrolFlag:
            default:
                MachineState = State.Patrol;
                break;
        }

        switch(MachineState)
        {
            case State.Chase:
                ChasePlayer();
                break;
            case State.Attack:
                AttackPlayer();
                break;
            case State.Patrol:
            default:
                Patroling();
                break;
        }

        Flags = 0;
        //if (!playerInSightRange && !playerInAttackRange) Patroling();
        //if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        //if (playerInAttackRange && playerInSightRange) AttackPlayer();
        if (health <= 0)
        { 
            DestroyEnemy();
            //this.enabled = false;
        }
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        
        //TODO: Add enemy functionality https://teamsurge.atlassian.net/browse/TS-42
        /*
        GameObject projectile = ProjectilePool.GetPooledObject();
        if (!alreadyAttacked && projectile != null)
        {
            projectile.SetActive(true);
            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }*/
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }


    public void TakeDamage(float damage)
    {
        health -= damage;
        enemyHealth.ModifyHealth(-damage);
    }
    private void DestroyEnemy()
    {
        gameObject.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    public void TakeSlow(int ModifiedSpeed)
    {
        this.GetComponent<NavMeshAgent>().speed = ModifiedSpeed;
    }

    public void TakeSlow(float ModifiedSpeed)
    {
        this.GetComponent<NavMeshAgent>().speed = ModifiedSpeed * this.GetComponent<NavMeshAgent>().speed;
    }
}
