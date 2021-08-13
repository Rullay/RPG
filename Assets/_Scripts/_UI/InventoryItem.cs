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
    public GameObject equipedItemObject;

    private bool isItemEquiped;
    public string slot_Type;

    void Update()
    {
        SetSprite();
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


    void SetSprite()
    {
        for (int i = 0; i < items.Count; i++)
        {
            slots[i].GetComponent<Image>().sprite = items[i].GetComponent<Item>().item_Sprite;
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
                    if (Items_slots[j].GetComponent<InventoryItem>().equipedItemObject == items[i])
                    {
                        if (GetComponent<InventoryItem>().equipedItemObject != null)
                        {
                            Items_slots[j].GetComponent<InventoryItem>().equipedItemObject = equipedItemObject;
                            equipedItemObject = items[i];
                            text_in_Button.text = "";
                            panel_Inventory_Item.SetActive(false);
                        }
                        isItemEquiped = true;
                    }
                }
                if (isItemEquiped == false)
                {
                    if (equipedItemObject == null)
                    {
                        equipedItemObject = items[i];
                        GetComponent<Image>().sprite = equipedItemObject.GetComponent<Item>().item_Sprite;
                        text_in_Button.text = "";
                        inventoryManager.GetComponent<InventoryManager>().GetItemStats(equipedItemObject);
                    }
                    else
                    {
                        equipedItemObject = items[i];
                        GetComponent<Image>().sprite = equipedItemObject.GetComponent<Item>().item_Sprite;
                    }
                    panel_Inventory_Item.SetActive(false);

                }
                isItemEquiped = false;
            }
        }
        inventoryManager.GetComponent<InventoryManager>().ReEquipedSprite();
        inventoryManager.GetComponent<InventoryManager>().ReEquipedItem();
    }


    /*public void ReEquipedItem()
    {
        inventoryManager.GetComponent<InventoryManager>().ReEquipedItem();
        for (int i = 0; i < Items_slots.Count; i++)
        {
            if (Items_slots[i].GetComponent<InventoryItem>().equipped_Item != null && Items_slots[i].activeSelf == true)
            {
                Debug.Log(i);
                Items_slots[i].GetComponent<InventoryItem>().inventoryManager.GetComponent<InventoryManager>().EquipedItem(Items_slots[i].GetComponent<InventoryItem>().equipped_Item);
            }
        }
    }


    void ReEquipedSprite()
    {

        for(int j = 0; j < Items_slots.Count; j++)
        {
            if(Items_slots[j].GetComponent<InventoryItem>().equipped_Item != null)
            {               
                Items_slots[j].GetComponent<Image>().sprite = Items_slots[j].GetComponent<InventoryItem>().equipped_Item.GetComponent<Item>().item_Sprite;
            }
           
        }
        
    }*/
}

