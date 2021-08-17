using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private GameObject panel_Inventory_Item;
    public List<GameObject> items;
    [SerializeField] private List<GameObject> slots;
    [SerializeField] private Text text_in_Button;
    public GameObject equipedItemObject;
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
            for (int i = 0; i < GameManager.Instance.InventoryManager.inventory_Types.Count; i++)
            {
                GameManager.Instance.InventoryManager.inventory_Types[i].GetComponent<InventoryItem>().panel_Inventory_Item.SetActive(false);
            }
            panel_Inventory_Item.SetActive(true);
        }
    }


    void SetSprite()
    {
        for (int i = 0; i < items.Count; i++)
        {
            slots[i].SetActive(true);
            slots[i].GetComponent<Slot>().itemSlot = items[i];
            slots[i].GetComponent<Image>().sprite = slots[i].GetComponent<Slot>().itemSlot.GetComponent<Item>().item_Sprite;
        }
    }

    public void Equiped(GameObject Item)
    {
        for (int j = 0; j < GameManager.Instance.InventoryManager.inventory_Types.Count; j++)
        {
            if (GameManager.Instance.InventoryManager.inventory_Types[j].GetComponent<InventoryItem>().equipedItemObject == Item)
            {
                GameManager.Instance.InventoryManager.inventory_Types[j].GetComponent<InventoryItem>().equipedItemObject = equipedItemObject;
            }
        }

        if (!equipedItemObject)
        {
            text_in_Button.text = "";
        }
        equipedItemObject = Item;
        GetComponent<Image>().sprite = equipedItemObject.GetComponent<Item>().item_Sprite;
        panel_Inventory_Item.SetActive(false);
        GameManager.Instance.InventoryManager.GetComponent<InventoryManager>().ReEquipedSprite();
        GameManager.Instance.InventoryManager.GetComponent<InventoryManager>().ReEquipedItem();
    }

}

