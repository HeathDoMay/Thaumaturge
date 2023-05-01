using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{
    [Header("Health")]
    public float maxHealth;
    private float currentHealth;

    [SerializeField] private Canvas healthBarUI;
    [SerializeField] private Slider slider;

    private void Awake()
    {
        healthBarUI = this.gameObject.GetComponentInChildren<Canvas>();
        slider = this.gameObject.GetComponentInChildren<Slider>();
        currentHealth = maxHealth;
        slider.value = CalculateHealthbar();
    }

    private void Update()
    {
        if (currentHealth < maxHealth)
        {
            healthBarUI.enabled = true;
        }
        else
        {
            healthBarUI.enabled = false;
        }
    }

    public void TakeDamage(float damageToApply)
    {
        currentHealth -= damageToApply;
        Debug.Log(currentHealth);
        slider.value = CalculateHealthbar();

        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //returns a percentage for the slider to set to
    private float CalculateHealthbar()
    {
        return currentHealth / maxHealth;
    }
}
