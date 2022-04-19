using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerBullet : MonoBehaviour
{
    public MemorySO SlowShot;
    public float damageValue;

    private int slowInt;
    private float slowFloat;
    private string wallTag = "WALL";
    private string enemyTag = "ENEMY";
    private string BossTag = "BOSS";
    private string WingTag = "WING";

    void Start()
    {
        InitializeMemoryValues();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == wallTag)
        {
            gameObject.SetActive(false);
            //Debug.Log("Collided w wall");
        }
        if (collision.gameObject.tag == enemyTag)
        {
            if (slowInt != 0)
            {
                collision.gameObject.GetComponent<AI>().TakeSlow(slowInt);
            }
            if (slowFloat != 0.0f)
            {
                collision.gameObject.GetComponent<AI>().TakeSlow(slowFloat);
            }
            collision.gameObject.GetComponent<AI>().TakeDamage(damageValue);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == BossTag)
        {
            collision.gameObject.GetComponent<Boss>().TakeDamage(50);
            //Debug.Log(damageValue);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == WingTag)
        {
            gameObject.SetActive(false);
        }
    }

    void InitializeMemoryValues()
    {
        slowInt = SlowShot != null ? SlowShot.IntValue : 0;
        slowFloat = SlowShot != null ? SlowShot.FloatValue : 0.0f;
    }
}
