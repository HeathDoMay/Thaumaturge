using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [Header("Health")]
    public float maxHealth;
    private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageToApply)
    {
        currentHealth -= damageToApply;
        Debug.Log(currentHealth);

        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
