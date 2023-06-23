using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth; // Reference to Plyer Health
    private Slider healthBar; // Slider
    public Image fillImage; // Health Fill

    // Start is called before the first frame update
    void Awake()
    {
        healthBar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.value <= healthBar.minValue) {
            fillImage.enabled = false;
        }
        if (healthBar.value > healthBar.minValue && !fillImage.enabled) {
            fillImage.enabled = true;
        }

        float Value = playerHealth.currentHealth / playerHealth.maxHealth;
        healthBar.value = Value;
    }
}
