using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[CreateAssetMenu]
public class MemorySO : ScriptableObject
{
    public int UnlockValue;
    public int IntValue;
    public float FloatValue;

    public string MemoryName;
    public string Description;
    public string FlavorText;

    public Sprite icon;
}