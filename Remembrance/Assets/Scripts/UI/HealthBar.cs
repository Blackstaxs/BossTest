using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private float updateSpeedSeconds = 0.2f;
    [SerializeField]
    private float positionOffset;

    private Health health;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void SetHealth(Health health)
    {
        this.health = health;
        health.OnHealthPercentChanged += HandleHealthChanged;
        healthText.text = health.CurrentHealth + "/" + health.GetMaxHealth();
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
        healthText.text = health.CurrentHealth + "/" + health.GetMaxHealth();
    }

    private void LateUpdate()
    {
        transform.position = mainCamera.WorldToScreenPoint(health.transform.position + Vector3.up * positionOffset);
    }
}
