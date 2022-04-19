using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvents : MonoBehaviour
{
    void Awake()
    {
    }
    
    void OnEnable()
    {
        EventManager.instance.TestEvent += SomeFunction;
    }

    void OnDisable()
    {
    }

    public void SomeFunction(object o, EventArgs e)
    {
        Debug.Log("Some Function was called!");
        EventManager.instance.TestEvent -= SomeFunction;
        EventManager.instance.TestEvent += SomeOtherFunction;
    }
    
    public void SomeOtherFunction(object o, EventArgs e)
    {
        Debug.Log("Some Other Function was called!");
        EventManager.instance.TestEvent -= SomeOtherFunction;
        EventManager.instance.TestEvent += SomeThirdFunction;
    }

    public void SomeThirdFunction(object o, EventArgs e)
    {
        Debug.Log("Some Third Function was called!");
        EventManager.instance.TestEvent -= SomeThirdFunction;
        EventManager.instance.TestEvent += SomeFunction;
    }
}
