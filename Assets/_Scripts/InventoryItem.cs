using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private GameObject panel_Inventory_Item;

    void Start()
    {
        
    }

    
    void Update()
    {
       
    }

    public void Panel_Inventory_Item()
    {
        Debug.Log(1);
        if (panel_Inventory_Item.activeSelf == true)
        {
            panel_Inventory_Item.SetActive(false);
        }
        else
        {
            panel_Inventory_Item.SetActive(true);
        }
    }
}
