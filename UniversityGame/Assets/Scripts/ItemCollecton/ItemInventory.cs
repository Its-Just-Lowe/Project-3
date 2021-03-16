using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    public List<ItemSO> items;

    public void AddItem(ItemSO itemToAdd)
    {
        items.Add(itemToAdd);
    }

    public void RemoveItem(ItemSO itemToRemove)
    {
        items.Remove(itemToRemove);
    }
}
