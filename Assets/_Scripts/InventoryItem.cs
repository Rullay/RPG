using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private GameObject panel_Inventory_Item;
    [SerializeField] private List<GameObject> items;
    [SerializeField] private List<GameObject> slots;

    //slot
    /*[SerializeField] private GameObject slot_0;
    [SerializeField] private GameObject slot_1;
    [SerializeField] private GameObject slot_2;
    [SerializeField] private GameObject slot_3;
    */

    void Start()
    {
        
    }

    
    void Update()
    {
        Item_in_slot();
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


    void Item_in_slot()
    {
        for(int i = 0; i < items.Count; i++)
        {
            for(int j = 0; j < slots.Count; j++)
            {
                if(i == j)
                {
                    slots[i].GetComponent<Image>().sprite = items[i].GetComponent<Item>().item_Sprite;
                }
            }
           // items[i].
        }
    }

    public void Equiped()
    {
        
        for (int i = 0; i < slots.Count; i++)
        {
            if(slots[i].GetComponent<Slot>().clik == true)
            {
                GetComponent<Image>().sprite = items[i].GetComponent<Item>().item_Sprite;
            }
        }
    }

}
