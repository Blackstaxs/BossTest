using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{
    private string wallTag = "WALL";
    private float delayTime = 6.0f;

    void Start()
    {
        Invoke("DestroyRock", delayTime);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == wallTag)
        {
            DestroyRock();
        }
    }

    private void DestroyRock()
    {
        Destroy(gameObject);
    }

}
