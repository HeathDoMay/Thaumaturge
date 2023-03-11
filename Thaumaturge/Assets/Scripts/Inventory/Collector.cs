using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        // looking for Collectible reference
        Collectible collectible = collision.GetComponent<Collectible>();

        // if collectible does not equal null then the object will be collected
        if(collectible != null)
        {
            collectible.Collect();
        }
    }
}
