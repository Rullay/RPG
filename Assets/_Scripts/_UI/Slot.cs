using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject itemSlot;
    private GameObject inventoryItem;

    private void Start()
    {
        inventoryItem = transform.parent.parent.parent.gameObject;        
    }

    public void Clik()
    {
        if(itemSlot)
        {
            inventoryItem.GetComponent<InventoryItem>().Equiped(itemSlot);
        }  
    }
    public void DescriptionOn()
    {
        inventoryItem.GetComponent<InventoryItem>().Description(itemSlot);
    }

    public void DescriptionOff()
    {
        inventoryItem.GetComponent<InventoryItem>().DescriptionOff();
    }
}
