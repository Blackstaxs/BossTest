using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public GameObject PooledObject;
    public int InstanceAmount = 10;

    private List<GameObject> ObjectInstances;

    public GameObject GetPooledObject(bool setActive = false)
    {
        GameObject holder = null;
       for(int i = 0; i < InstanceAmount; i++)
        {
            if(!ObjectInstances[i].activeInHierarchy)
            {
                holder = ObjectInstances[i];
                holder.SetActive(setActive);
                return holder;
            }
        }
        return holder;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject tmp;

        ObjectInstances = new List<GameObject>();
        for(int i = 0; i < InstanceAmount; i++)
        {
            tmp = Instantiate(PooledObject);
            tmp.SetActive(false);
            ObjectInstances.Add(tmp);
        }
    }

    void Awake()
    {
        SharedInstance = this;
    }
}
