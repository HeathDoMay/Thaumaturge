using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHP;
    public float currentHP;

    public bool canHeal;

    public void Awake()
    {
        currentHP = playerHP;
    }

    public void Update()
    {
        if(currentHP == 100)
        {
            canHeal = false;
        }
        else 
        {
            canHeal = true;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHP = currentHP - damage;
        Debug.Log(currentHP);
    }
}
