using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //Panel
    [SerializeField] private List<GameObject> inventory_Types;

    public void ItemDispenser(GameObject ItemObject)
    {
        for (int i = 0; i < inventory_Types.Count; i++)
        {
            if (ItemObject.GetComponent<Item>().item_Type == inventory_Types[i].GetComponent<InventoryItem>().slot_Type)
            {
                inventory_Types[i].GetComponent<InventoryItem>().items.Add(ItemObject);
            }
        }
    }

    public void GetItemStats(GameObject TECH_Actual_Item)
    {
        GameManager.Instance.Player.GetComponent<CharacterPlayer>().AddItemStats(TECH_Actual_Item);
    }


    public void ReEquipedItem()
    {
        GameManager.Instance.Player.GetComponent<CharacterPlayer>().LoadStats();
        for (int i = 0; i < inventory_Types.Count; i++)
        {
            if (inventory_Types[i].GetComponent<InventoryItem>().equipedItemObject != null && inventory_Types[i].activeSelf == true)
            {
                GetItemStats(inventory_Types[i].GetComponent<InventoryItem>().equipedItemObject);
            }
        }
    }

    public void ReEquipedSprite()
    {
        for (int j = 0; j < inventory_Types.Count; j++)
        {
            if (inventory_Types[j].GetComponent<InventoryItem>().equipedItemObject)
            {
                inventory_Types[j].GetComponent<Image>().sprite = inventory_Types[j].GetComponent<InventoryItem>().equipedItemObject.GetComponent<Item>().item_Sprite;
            }
        }
    }
}

