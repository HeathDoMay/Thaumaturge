using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InventoryItem
{
    public ItemData itemData;
    public int stackSize;

    // Constructor for the inventory item
    public InventoryItem(ItemData item)
    {
        itemData = item;
        AddToStack();
    }

    // Adds to a stack
    public void AddToStack()
    {
        if(itemData.isStackable == true)
        {
            stackSize++;
        }
    }

    public void RemoveFromStack()
    {
        if(itemData.isStackable == true)
        {
            stackSize--;
        }
    }
}
