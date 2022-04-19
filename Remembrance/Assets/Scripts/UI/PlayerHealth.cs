using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage;

    [SerializeField]
    private Text healthText;

    [SerializeField]
    private int maxHealth = 100;

    private int minHealth = 0;

    [SerializeField]
    private float updateSpeedSeconds = 0.2f;

    [SerializeField]
    public float CurrentHealth { get; private set; }

    void Start()
    {
        CurrentHealth = maxHealth;
        healthText.text = "Health: " + CurrentHealth + "/" + maxHealth;
    }

    public void ModifyHealth(float amount)
    {
        CurrentHealth += amount;

        float currentHealthPercent = (float)CurrentHealth / (float)maxHealth;
        HandleHealthChanged(currentHealthPercent);
        if (CurrentHealth <= minHealth)
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        Debug.Log("Player has died!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ModifyHealth(-10);
        }
    }

    private void HandleHealthChanged(float percent)
    {
        StartCoroutine(ChangeToPercent(percent));
    }

    private IEnumerator ChangeToPercent(float percent)
    {
        float preChangePercent = foregroundImage.fillAmount;
        float elapsed = 0f;

        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePercent, percent, elapsed / updateSpeedSeconds);
            yield return null;
        }

        foregroundImage.fillAmount = percent;
        healthText.text = "Health: " + CurrentHealth + "/" + maxHealth;
    }
}
