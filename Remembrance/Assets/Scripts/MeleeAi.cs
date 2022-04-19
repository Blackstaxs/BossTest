using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatisGround, whatisPlayer;

    public int maxHealth;

    //Patroling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public State MachineState;
    
    private const int DefaultFlag = 0;
    private const int SightedFlag = 1;
    private const int AttackFlag = 2;
    private const int PatrolFlag = 3;
    private int Flags = 0;
    private float health;
    private Rigidbody rb;
    public Transform pointAttack;
    private Animator anim;
    private float SphereRadius = 0.3f;

    public enum State
    {
        Default = 0,
        Patrol = 3,
        Chase = 1,
        Attack = 2,
    }

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        MachineState = State.Default;
        anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        health = maxHealth;
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatisPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatisPlayer);

        if (playerInSightRange)
            Flags |= SightedFlag;
        if (playerInAttackRange)
            Flags |= AttackFlag;
        if (Flags == DefaultFlag)
            Flags |= PatrolFlag;

        switch (Flags)
        {
            case SightedFlag:
                MachineState = State.Chase;
                break;
            case AttackFlag:
                MachineState = State.Attack;
                break;
            case PatrolFlag:
            default:
                MachineState = State.Patrol;
                break;
        }

        switch (MachineState)
        {
            case State.Chase:
                //transform.LookAt(player);
                ChasePlayer();
                break;
            case State.Attack:
                //stopChase();
                AttackPlayer();
                break;
            case State.Patrol:
            default:
                Patroling();
                break;
        }

        Flags = 0;

        if (health <= 0)
        {
            anim.SetTrigger("death");
            Invoke("DestroyEnemy", 1.0f);
        }
    }

    private void Patroling()
    {
        //if (!walkPointSet) SearchWalkPoint();
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatisGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        anim.SetTrigger("chase");
    }

    private void stopChase()
    {
        this.GetComponent<NavMeshAgent>().isStopped = true;
    }

    private void AttackPlayer()
    {
        anim.SetTrigger("attack");
        Collider []playerHit = Physics.OverlapSphere(pointAttack.position, SphereRadius, whatisPlayer);
        if (playerHit.Length != 0)
        {
            //player take damage
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (pointAttack == null)
            return;
        Gizmos.DrawWireSphere(pointAttack.position, SphereRadius);
    }
    private void ResetAttack()
    {
        //alreadyAttacked = false;
    }


    public void TakeDamage(float damage)
    {
        health -= damage;
        anim.SetTrigger("damage");
    }
    private void DestroyEnemy()
    {
        gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
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
