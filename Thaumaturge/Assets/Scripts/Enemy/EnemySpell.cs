using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class EnemySpell : MonoBehaviour
{
    [Header("Spell To Cast")]
    public SpellScriptableObject spellToCast;

    private SphereCollider myCollider;
    private Rigidbody myRigidbody;

    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = spellToCast.spellRadius;

        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.isKinematic = true;

        Destroy(this.gameObject, spellToCast.lifeTime);
    }

    private void Update()
    {
        if (spellToCast.speed > 0)
        {
            transform.Translate(Vector3.forward * spellToCast.speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // apply spell effects to whatever we hit
        // apply hit particle effects
        // apply sound effects

        if (other.gameObject.tag == "Player")
        {
            PlayerMagicSystem playerHealth = other.GetComponent<PlayerMagicSystem>();
            playerHealth.TakeDamage(spellToCast.damageAmount);
        }

        Destroy(this.gameObject);
    }
}