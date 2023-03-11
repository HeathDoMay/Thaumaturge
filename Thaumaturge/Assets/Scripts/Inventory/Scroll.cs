using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scroll : MonoBehaviour, Collectible
{
    public static event HanldeScrollCollected onScrollCollected;
    public delegate void HanldeScrollCollected(ItemData itemData);
    
    [Header("Inventory Item Scribtable Object")]
    public ItemData scrollData;

    [Tooltip("Bool to Check if scroll is collected")]
    public bool isCollected;

    // if object is collected the game object will be destroyed, data collected, and isColledted is set to true
    public void Collect()
    {
        Destroy(gameObject);
        onScrollCollected?.Invoke(scrollData);
        isCollected = true;
    }
}
