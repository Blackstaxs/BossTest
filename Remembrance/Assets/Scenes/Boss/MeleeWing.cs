using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeWing : MonoBehaviour
{
    public NavMeshAgent agent;
    private Vector3 attackArea;
    public Transform player;
    bool dashReady = true;
    bool alreadyAttacked = false;
    public float delayTime;
    public ParticleSystem damageParticle;
    private string playerTag = "PLAYER";
    private float TackleDelay = 1.0f;

    void Update()
    {
        if (alreadyAttacked) return;
        Invoke("Tackle", TackleDelay);
        alreadyAttacked = true;
    }
    private void Tackle()
    {
        attackArea = new Vector3(player.position.x, 0, player.position.z);
        Invoke("dashBoss", delayTime);
        Invoke(nameof(ResetAttack), delayTime);
    }
    private void dashBoss()
    {
        if (dashReady == true)
        {
            agent.SetDestination(attackArea);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            damageParticle.Play();
        }
        else
        {
            damageParticle.Play();
        }
    }
}
