using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //Panel
    public List<GameObject> inventory_Types;
    [SerializeField] private List<GameObject> Hands_1;
    [SerializeField] private List<GameObject> Hands_2;

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
        GameManager.Instance.Player.GetComponent<StatsPlayer>().AddItemStats(TECH_Actual_Item);
    }


    public void ReEquipedItem()
    {
        //GameManager.Instance.Player.GetComponent<CharacterPlayer>().LoadStats();
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

    public void ChangeHands()
    {
        if (Hands_1[0].activeSelf == true)
        {
            for (int i = 0; i < Hands_2.Count; i++)
            {
                Hands_2[i].SetActive(true);
                Hands_1[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < Hands_2.Count; i++)
            {
                Hands_1[i].SetActive(true);
                Hands_2[i].SetActive(false);
            }
        }
        ReEquipedItem();
    }
}

