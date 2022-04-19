using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private string wallTag = "WALL";
    private string playerTag = "PLAYER";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == wallTag)
        {
            this.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == playerTag)
        {
            this.gameObject.SetActive(false);
        }

    }
}
