using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float openSpeed;
    [SerializeField] private float openHeight;
    [SerializeField] private bool itemRequired = false;
    [SerializeField] private ItemSO itemNeeded;

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
                if(playerInv.CompareItem(itemNeeded))
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
