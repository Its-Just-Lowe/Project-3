using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemSO item;
    [SerializeField] private GameObject itemSpriteObject;

    private void Start()
    {
        itemSpriteObject.GetComponent<SpriteRenderer>().sprite = item.sprite;
    }

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
    public Sprite sprite;
}
