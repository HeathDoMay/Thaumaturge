using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    private bool canAttack;
    private bool isAttacking;

    [SerializeField] public int damage;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform rangedAttackSpawnPoint;
    [SerializeField] private float attackCooldown;
    
    private float timer;

    // Start is called before the first frame update
    private void Awake()
    {
        canAttack = false;
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        canAttack = this.GetComponent<FieldOfView>().canSeePlayer;
        if(canAttack == true && isAttacking == false)
        {
            isAttacking = true;
            timer = attackCooldown;
            RangeAttack();
        }

        if (isAttacking == true)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                isAttacking = false;
            }
        }
    }

    private void RangeAttack()
    {
        Instantiate(projectile, rangedAttackSpawnPoint.position, rangedAttackSpawnPoint.rotation);
        Debug.Log("attack called");
    }
}