using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPoolScript : MonoBehaviour
{
    public ObjectPool Pool1;
    public ObjectPool Pool2;
    public Vector3 CubeVector;
    public Vector3 SphereVector;
    
    private PlayerInput Controls;
    private InputAction Trigger1;
    private InputAction Trigger2;
    private InputAction Trigger3;
    private List<GameObject> Objects;
    private Vector3 Transform1;
    private Vector3 Transform2;

    void Awake()
    {
        Controls = new PlayerInput();
    }

    void OnEnable()
    {
        Trigger1 = Controls.Testing.Trigger1;
        Trigger1.Enable();
        Trigger2 = Controls.Testing.Trigger2;
        Trigger2.Enable();
        Trigger3 = Controls.Testing.Trigger3;
        Trigger3.Enable();
    }

    void OnDisable()
    {
        Trigger1.Disable();
        Trigger2.Disable();
        Trigger3.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        Objects = new List<GameObject>();
        Debug.Log("Script initialized");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject holder;
        if(Trigger1.triggered)
        {
            Debug.Log("Trigger1");
            holder = Pool1.GetPooledObject();
            if (holder != null)
            {
                holder.transform.Translate(Transform1);
                Transform1 += CubeVector;
                holder.SetActive(true);
                Objects.Add(holder);
            }
            else
            {
                Debug.Log("No available objects");
            }
        }
        if(Trigger2.triggered)
        {
            Debug.Log("Trigger2");
            holder = Pool2.GetPooledObject();
            if (holder != null)
            {
                holder.transform.Translate(Transform2);
                Transform2 += SphereVector;
                holder.SetActive(true);
                Objects.Add(holder);
            }
            else
            {
                Debug.Log("No available objects");
            }
        }
        if(Trigger3.triggered)
        {
            Debug.Log("Trigger3");
            foreach (GameObject game in Objects)
                game.SetActive(false);
            Objects.Clear();
        }
    }
}
