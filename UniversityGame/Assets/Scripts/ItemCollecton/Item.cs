using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSO item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<ItemInventory>().AddItem(item);
            Destroy(gameObject);
        }
    }
}

[CreateAssetMenu(fileName = "New Item", menuName = "Custom/Item")]
public class ItemSO : ScriptableObject
{
    public string name;
}
