using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    //This is for your projectile or thing doing the damage.
    public float dmgAmount = 45;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIT");
        GameObject hitObject = collision.gameObject;
        TryDamageObject(hitObject);
    }

    void TryDamageObject(GameObject objectToDamage)
    {
        if (objectToDamage.TryGetComponent(out Damageable damageableObject))
        {
            damageableObject.DealDamage(-dmgAmount);
        }
        else
        {
            Debug.Log("That object cannot be damaged.");
        }
    }
}
