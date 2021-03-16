using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    [SerializeField] private List<ItemSO> items;

    public void AddItem(ItemSO itemToAdd)
    {
        items.Add(itemToAdd);
    }

    public void RemoveItem(ItemSO itemToRemove)
    {
        items.Remove(itemToRemove);
    }

    public bool CompareItem(ItemSO itemToCompare)
    {
        if (items.Contains(itemToCompare))
            return true;

        return false;
    }
}
