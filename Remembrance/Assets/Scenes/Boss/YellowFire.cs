using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowFire : MonoBehaviour
{
    public float delayTime;
    public float castTime;
    public GameObject blueWall;
    private Vector3 attackArea;
    public Transform player;
    private float adjustmentX = 2f;
    private float adjustmentY = 2f;
    private float adjustmentZ = 5f;
    void Start()
    {
        Invoke("DestroyFire", delayTime);
        Invoke("FireBarrier", delayTime - castTime);
    }

    private void FireBarrier()
    {
        attackArea = new Vector3(player.position.x - adjustmentX, adjustmentY, player.position.z + adjustmentZ);
        Instantiate(blueWall, attackArea, Quaternion.identity);
    }

    private void DestroyFire()
    {
        gameObject.SetActive(false);
    }
}
