using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    [Header("Inventory Item Info")]
    public string displayName;
    public GameObject prefab;
    public bool isStackable;
}
