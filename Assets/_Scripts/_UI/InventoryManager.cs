using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //Panel
    public List<GameObject> inventory_Types;
    private List<int> loadInventory;
    private List<int> loadEquipedItem;
    [SerializeField] private List<GameObject> Hands_1;
    [SerializeField] private List<GameObject> Hands_2;
    [SerializeField] private Text description;
    private ItemWeapone item_Weapone;
    private ItemArmor item_Armor;
    private ItemArtifact item_Artifact;


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
        GameManager.Instance.Player.GetComponent<StatsPlayer>().LoadStats();
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

    public void Description(GameObject item)
    {
        item_Armor = item.GetComponent<ItemArmor>();
        item_Weapone = item.GetComponent<ItemWeapone>();
        item_Artifact = item.GetComponent<ItemArtifact>();
        if (item_Weapone)
        {
            description.text = "Description:  \n Type " + item_Weapone.item_Type + "\n Damage: " + item_Weapone.STATS_weapone_Damage + " \n Attack speed " + item_Weapone.STATS_attack_Speed;
        }
        if (item_Armor)
        {
            description.text = "Description:  \n Type " + item_Armor.item_Type + "\n Health: " + item_Armor.STATS_armor_Health + " \n Stamina " + item_Armor.STATS_armor_Stamina;
        }
        if(item_Artifact)
        {
            description.text = "Description:  \n Type " + item_Artifact.item_Type + "\n ????? ";
        }


    }
    public void DescriptionOff()
    {

        description.text = "";
    }



    // Ниже ебучий пиздец 

    public void SaveInventory()
    {
        for (int i = 0; i < inventory_Types.Count; i++)
        {
            for (int j = 0; j < inventory_Types[i].GetComponent<InventoryItem>().items.Count; j++)
            {
                if(inventory_Types[i].GetComponent<InventoryItem>().items[j])
                {
                    PlayerPrefs.SetInt("Item_id " + inventory_Types[i].GetComponent<InventoryItem>().items[j].GetComponent<Item>().id, inventory_Types[i].GetComponent<InventoryItem>().items[j].GetComponent<Item>().id);
                }
            }
        }
    }


    public void LoadInventory()
    {
        // вместо 100 будет количество сохранненых шмоток
        for ( int i  = 0; i < 100; i++)
        {

            loadInventory.Add(PlayerPrefs.GetInt("Item_i " + i));

        }
        for (int i = 0; i < loadInventory.Count; i++)
        {
            /* for(int j = 0; j < список всех предметов.Count; j++)
             {
                if(список всех предметов[j].id ==  loadInventory[i])
                {
                    ItemDispenser(список всех предметов[j])
                {
             }*/
        }

    }

    public void SaveEquipedItem()
    {
        for (int i = 0; i < inventory_Types.Count; i++)
        {
            if (inventory_Types[i].GetComponent<InventoryItem>().equipedItemObject)
            {
                PlayerPrefs.SetInt("Item_Equiped_id " + inventory_Types[i].GetComponent<InventoryItem>().equipedItemObject.GetComponent<Item>().id, inventory_Types[i].GetComponent<InventoryItem>().equipedItemObject.GetComponent<Item>().id);
            }
        }
    }
    public void LoadEquipedItem()
    {

        for (int i = 0; i < 8; i++)
        {

            loadEquipedItem.Add(PlayerPrefs.GetInt("Item_Equiped_id " + i));

        }
        for (int i = 0; i < loadInventory.Count; i++)
        {
            /* for(int j = 0; j < список всех предметов.Count; j++)
             {
                if(список всех предметов[j].id ==  loadInventory[i])
                {
                     for (int n = 0; n < inventory_Types.Count; n++)
                     {
                          if( inventory_Types.GetComponent<InventoryItem>().slot_Type == список всех предметов[j].GetComponent<Item>().item_Type)
                          {
                                Equiped(список всех предметов[j])
                          }
                     }
                {
             }*/
        }

    }
}

