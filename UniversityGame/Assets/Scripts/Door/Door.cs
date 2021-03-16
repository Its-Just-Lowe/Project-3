using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float openSpeed;
    public float openHeight;
    public bool itemRequired = false;
    public ItemSO itemNeeded;

    void OpenDoor()
    {
        float desiredY = transform.position.y + openHeight;
        while(transform.position.y < desiredY)
        {
            Vector3 newPos = transform.position + new Vector3(0, openSpeed * Time.deltaTime, 0);
            transform.position = newPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ItemInventory playerInv = collision.gameObject.GetComponent<ItemInventory>();
            if(itemRequired)
            {
                if(playerInv.items.Contains(itemNeeded))
                {
                    playerInv.RemoveItem(itemNeeded);
                    OpenDoor();
                }
            }
            else
            {
                OpenDoor();
            }
        }
    }
}
