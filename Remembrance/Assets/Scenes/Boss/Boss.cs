using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public int MaxHealth;

    public Transform centerRoom;
    public Transform topRoom;
    public ParticleSystem particlesWall;
    public NavMeshSurface MeshSurface;
    public GameObject breakWall;
    public GameObject bossWing1;
    public GameObject bossWing2;
    public GameObject bossWing3;
    public GameObject bossWing4;
    public GameObject laserZone;
    public GameObject wingBarrier;
    public GameObject laserGun;
    public int bosDamage;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public State MachineState;

    private const int Phase3Flag = 1;
    private const int Phase2Flag = 2;
    private const int Phase1Flag = 3;
    private int Flags = 0;
    public float health;
    private float Phase1Health;
    private float Phase3Health;
    private Rigidbody rb;
    private int rotationSpeed = 800;
    private Vector3 attackArea;
    private LineRenderer lr;
    private float laserTime = 5f;

    bool onCenter = false;
    bool onTop = false;
    bool alreadyAttacked = false;
    bool rotateShields = false;
    bool dashReady = true;
    bool EvadeReady = true;
    bool damageEnable = true;

    //damage
    public MeshRenderer rn;
    public float flashTime = 1f;

    //eye
    public Material damageEye;
    public Material normalEye;
    public GameObject Eyeshader;

    public enum State
    {
        Default = 0,
        Phase1 = 3,
        Phase3 = 1,
        Phase2 = 2,
    }

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        MachineState = State.Default;
        lr = laserGun.GetComponent<LineRenderer>();
        rn = Eyeshader.GetComponent<MeshRenderer>();

    }

    void OnEnable()
    {
        health = MaxHealth;
        Phase1Health = (float)(health * 0.7);
        Phase3Health = (float)(health * 0.4);
    }

    void OnDisable()
    {
        agent.enabled = false;
    }

    private void Update()
    {
        if (health > Phase1Health)
            Flags |= Phase1Flag;
        if (health <= Phase3Health)
            Flags |= Phase3Flag;
        if (Flags == 0)
            Flags |= Phase2Flag;

        switch (Flags)
        {
            case Phase1Flag:
                MachineState = State.Phase1;
                break;
            case Phase3Flag:
                MachineState = State.Phase3;
                break;
            case Phase2Flag:
            default:
                MachineState = State.Phase2;
                break;
        }

        switch (MachineState)
        {
            case State.Phase3:
                Phase3();
                break;
            case State.Phase2:
                Phase2();
                break;
            case State.Phase1:
            default:
                Phase1();
                break;
        }

        Flags = 0;
        if (health <= 0)
        {
            DestroyEnemy();
        }
    }

    private void Phase1()
    {
        Debug.Log("phase1");
        BossEvade();
    }

    private void BossEvade()
    {
        if (EvadeReady == true)
        {
            transform.LookAt(new Vector3(player.position.x, this.transform.position.y, player.position.z));
            transform.Translate(new Vector3(-2, 0, 0) * Time.deltaTime * 10);
        }
    }

    private void Phase2()
    {
        EvadeReady = false;
        Debug.Log("phase2");
        rotateShields = true;
        rotateWings();
        if (alreadyAttacked) return;
        Invoke("Tackle", 1f);
        alreadyAttacked = true;
    }

    private void rotateWings()
    {
        if(rotateShields == true)
        {
            bossWing1.transform.RotateAround(this.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
            bossWing2.transform.RotateAround(this.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
            bossWing3.transform.RotateAround(this.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
            bossWing4.transform.RotateAround(this.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void stopChase()
    {
        this.GetComponent<NavMeshAgent>().isStopped = true;
    }

    private void Tackle()
    {
        attackArea = new Vector3(player.position.x, 0, player.position.z);
        transform.LookAt(new Vector3(player.position.x, this.transform.position.y, player.position.z));
        Invoke("dashBoss", 2f);
        Invoke(nameof(ResetAttack), 2f);
    }

    private void dashBoss()
    {
        if (dashReady == true)
        {
            agent.SetDestination(attackArea);
        }
    }

    private void laserBoss()
    {
        lr.SetPosition(0, this.transform.position);
        lr.SetPosition(1, new Vector3(attackArea.x, 1, attackArea.z));
    }

    private void laserTest()
    {
        lr.SetPosition(0, new Vector3(attackArea.x, 1, attackArea.z));
        lr.SetPosition(1, transform.up * 5000);
    }


    private void Phase3()
    {
        rotateShields = false;
        dashReady = false;
        laserGun.SetActive(true);
        bossWing1.SetActive(false);
        bossWing2.SetActive(false);
        bossWing3.SetActive(false);
        bossWing4.SetActive(false);
        MoveCenter();
        Invoke("MoveTop", 2.0f);
        Invoke("fireBarrier", 4.0f);
        if (alreadyAttacked) return;
        Invoke("LaserGun", laserTime);
        alreadyAttacked = true;
    }

    private void checkDistance()
    {
        if (Vector3.Distance(player.transform.position, attackArea) < 1.5)
        {
            player.GetComponent<Shoot>().TakeDamage(bosDamage);
        }
    }

    private void LaserGun()
    {
        attackArea = new Vector3(player.position.x, 0, player.position.z + 10);
        Instantiate(laserZone, attackArea, Quaternion.identity);
        Invoke("checkDistance", 0.5f);
        Invoke("laserTest", 0.5f);
        laserTime = 1f; 
        Invoke(nameof(ResetAttack), 0.5f);
    }



    [System.Obsolete]
    private void MoveTop()
    {
        if (onTop) return;
        agent.SetDestination(topRoom.position);
        particlesWall.Play();
        Invoke("wallOff", 1.0f);
        onTop = true;
    }

    private void MoveCenter()
    {
        if (onCenter) return;
        agent.SetDestination(centerRoom.position);
        onCenter = true;
    }

    private void fireBarrier()
    {
        transform.LookAt(new Vector3(centerRoom.position.x, this.transform.position.y, centerRoom.position.z));
        wingBarrier.SetActive(true);
    }

    [System.Obsolete]
    private void wallOff()
    {
        breakWall.gameObject.active = false;
        MeshSurface.BuildNavMesh();
    }


    public void TakeDamage(float damage)
    {
        Debug.Log(damageEnable);
        if (damageEnable == true)
        {
            health -= damage;
            FlashRed();
        }
    }

    void FlashRed()
    {
        Invoke("ResetColor", flashTime);
        damageEnable = false;
        rn.material = damageEye;
    }
    void ResetColor()
    {
        rn.material = normalEye;
        damageEnable = true;
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
}
