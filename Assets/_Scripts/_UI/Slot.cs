using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject itemSlot;
    private GameObject inventoryItem;

    private void Start()
    {
        inventoryItem = transform.parent.parent.gameObject;

        
    }
    public void Clik()
    {
        if(itemSlot)
        {
            Debug.Log(itemSlot);
            inventoryItem.GetComponent<InventoryItem>().Equiped(itemSlot);
        }  
    }
}
