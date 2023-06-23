using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar; // Slider
    public TextMeshProUGUI healthBarValue; // Value of Health

    public int maxHealth;
    public int currentHealth; 
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; // Set current to max
    }

    // Update is called once per frame
    void Update()
    {
        healthBarValue.text = currentHealth.ToString() + "/" + maxHealth.ToString();

        healthBar.value = currentHealth;
        healthBar.maxValue = maxHealth;
    }
}
