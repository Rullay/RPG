using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private GameObject panel_Inventory_Item;
    [SerializeField] private List<GameObject> items;
    [SerializeField] private List<GameObject> slots;
    [SerializeField] private Text text_in_Button;
    [SerializeField] private List<GameObject> Items_slots;
    private bool equipped_item;


    void Start()
    {
        
    }

    
    void Update()
    {
        Item_in_slot();
    }

    public void Panel_Inventory_Item()
    {
       
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
           
        }
    }

    public void Equiped()
    {
        
        for (int i = 0; i < slots.Count; i++)
        {
            if(slots[i].GetComponent<Slot>().clik == true && i < items.Count)
            {
              
                for (int j = 0; j < Items_slots.Count; j++)
                {              
                    if (Items_slots[j].GetComponent<Image>().sprite == items[i].GetComponent<Item>().item_Sprite)
                    {
                        if(GetComponent<Image>().sprite != null )
                        {
                            Items_slots[j].GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                            GetComponent<Image>().sprite = items[i].GetComponent<Item>().item_Sprite;
                        }                   
                        equipped_item = true;
                    }
                }
                if(equipped_item == false)
                {
                    GetComponent<Image>().sprite = items[i].GetComponent<Item>().item_Sprite;
                    text_in_Button.text = "";
                }
                equipped_item = false;
            }
        }
    }

}
