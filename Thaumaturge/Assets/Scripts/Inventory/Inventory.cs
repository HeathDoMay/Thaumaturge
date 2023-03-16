using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Inventory List / Dictionary")]
    public List<InventoryItem> inventory = new List<InventoryItem>();
    public Dictionary<ItemData, InventoryItem> itemDictionary = new Dictionary<ItemData, InventoryItem>();
    private InventoryItem pendingSpell;

    private void OnEnable()
    {
        Scroll.onScrollCollected += Add;
    }

    private void OnDisable()
    {
        Scroll.onScrollCollected -= Add;
    }

    public void Add(ItemData itemData)
    {
        // Do we have this item in our inventory if so increase its stack
        // else add it to the inventory
        if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.AddToStack();
            Debug.Log($"{item.itemData.displayName} total stack is now {item.stackSize}");
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            Debug.Log($"Added {itemData.displayName} to the inventory for the first time");
        }
    }

    public void Remove(ItemData itemData)
    {
        // Do we have this item in our inventory 
        // remove from stack
        // if items = 0 remove from inventory
        if(itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.RemoveFromStack();
            if(item.stackSize == 0)
            {
                inventory.Remove(item);
                itemDictionary.Remove(itemData);
            }
        }
    }

    public void SelectSpell(int index)
    {
        pendingSpell = inventory[index];
    }
}