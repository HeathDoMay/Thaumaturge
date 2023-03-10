using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scroll : MonoBehaviour, Collectible
{
    public static event HanldeScrollCollected onScrollCollected;
    public delegate void HanldeScrollCollected(ItemData itemData);
    public ItemData scrollData;
    public bool isCollected;

    public void Collect()
    {
        Destroy(gameObject);
        onScrollCollected?.Invoke(scrollData);
        isCollected = true;
    }
}
