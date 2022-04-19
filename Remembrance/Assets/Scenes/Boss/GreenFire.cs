using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenFire : MonoBehaviour
{
    public float delayTime;
    public float castTime;
    public GameObject fireWall;
    void Start()
    {
        Invoke("DestroyFire", delayTime);
        Invoke("FireBarrier", delayTime - castTime);
    }

    private void FireBarrier()
    {
        fireWall.GetComponent<rockSpawn>().GenerateWall();
    }

    private void DestroyFire()
    {
        gameObject.SetActive(false);
    }
}
