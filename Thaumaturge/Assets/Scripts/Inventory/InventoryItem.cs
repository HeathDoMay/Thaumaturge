using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InventoryItem
{
    // Reference to ScriptAbleObject 
    public ItemData itemData;

    // number of items in stack if stackable
    public int stackSize;

    // Constructor for the inventory item
    public InventoryItem(ItemData item)
    {
        itemData = item;
        AddToStack();
    }

    // Adds to a stack if stackable
    public void AddToStack()
    {
        if(itemData.isStackable == true)
        {
            stackSize++;
        }
    }

    // removes frome stack if stackable
    public void RemoveFromStack()
    {
        if(itemData.isStackable == true)
        {
            stackSize--;
        }
    }
}
