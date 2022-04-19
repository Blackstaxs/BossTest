using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningZone : MonoBehaviour
{
    public float delayTime = 2F;
    void Start()
    {
        Object.Destroy(gameObject, delayTime);
    }
}
