using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Damageable : MonoBehaviour
{
    Health health;

    //Instead of a constructor, you can create values in Awake())
    private void Awake()
    {
        health = GetComponent<Health>();
    }
    public void DealDamage(float damageAmount)
    {
        health.ChangeHealth(damageAmount);
    }
}
