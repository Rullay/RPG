using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private GameObject panel_Inventory_Item;
    [SerializeField] private GameObject inventoryManager;
    public List<GameObject> items;
    [SerializeField] private List<GameObject> slots;
    [SerializeField] private Text text_in_Button;
    [SerializeField] private List<GameObject> Items_slots;
    public GameObject equipped_Item;

    private bool equipped_item;
    public string slot_Type;




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
            for (int i = 0; i < Items_slots.Count; i++)
            {
                Items_slots[i].GetComponent<InventoryItem>().panel_Inventory_Item.SetActive(false);
            }
            panel_Inventory_Item.SetActive(true);
        }
    }


    void Item_in_slot()
    {
        for (int i = 0; i < items.Count; i++)
        {
            for (int j = 0; j < slots.Count; j++)
            {
                if (i == j)
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
            if (slots[i].GetComponent<Slot>().clik == true && i < items.Count)
            {

                for (int j = 0; j < Items_slots.Count; j++)
                {
                    if (Items_slots[j].GetComponent<InventoryItem>().equipped_Item == items[i])
                    {
                        if (GetComponent<InventoryItem>().equipped_Item != null)
                        {
                            equipped_Item = items[i];
                            Items_slots[j].GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                            GetComponent<Image>().sprite = equipped_Item.GetComponent<Item>().item_Sprite;
                            ReEquipedItem();
                            text_in_Button.text = "";
                            panel_Inventory_Item.SetActive(false);
                        }
                        equipped_item = true;
                    }
                }
                if (equipped_item == false)
                {
                    if (equipped_Item == null)
                    {
                        equipped_Item = items[i];
                        GetComponent<Image>().sprite = equipped_Item.GetComponent<Item>().item_Sprite;
                        text_in_Button.text = "";                   
                        inventoryManager.GetComponent<InventoryManager>().EquipedItem(equipped_Item);
                    }
                    else
                    {
                        equipped_Item = items[i];
                        GetComponent<Image>().sprite = equipped_Item.GetComponent<Item>().item_Sprite;
                        ReEquipedItem();
                    }
                    panel_Inventory_Item.SetActive(false);

                }
                equipped_item = false;
            }
        }
    }
    void ReEquipedItem()
    {
        inventoryManager.GetComponent<InventoryManager>().ReEquipedItem();
        for (int i = 0; i < Items_slots.Count; i++ )
        {
            if (Items_slots[i].GetComponent<InventoryItem>().equipped_Item != null)
            {
                Items_slots[i].GetComponent<InventoryItem>().inventoryManager.GetComponent<InventoryManager>().EquipedItem(Items_slots[i].GetComponent<InventoryItem>().equipped_Item);
            }           
        }
    }

}
