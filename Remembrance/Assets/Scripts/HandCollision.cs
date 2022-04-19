using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollision : MonoBehaviour
{
    private string playerTag = "PLAYER";
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            
            Debug.Log("player");
        }
    }
}
