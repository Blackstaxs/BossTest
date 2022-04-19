using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public static event Action<Health> OnHealthAdded = delegate { };
    public static event Action<Health> OnHealthRemoved = delegate { };

    [SerializeField]
    private int maxHealth = 50;

    [SerializeField]
    public float CurrentHealth { get; private set; }

    public event Action<float> OnHealthPercentChanged = delegate { };

    private void OnEnable()
    {
        CurrentHealth = maxHealth;
        OnHealthAdded(this);
    }

    public void ModifyHealth(float amount)
    {
        CurrentHealth += amount;

        float currentHealthPercent = (float)CurrentHealth / (float)maxHealth;
        OnHealthPercentChanged(currentHealthPercent);
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    private void OnDisable()
    {
        OnHealthRemoved(this);
    }
}
