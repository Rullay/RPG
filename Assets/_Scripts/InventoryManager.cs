using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //Panel
    [SerializeField] private GameObject panel_Inventory_Manager;
    [SerializeField] private List<GameObject> inventory_Types;
    [SerializeField] private GameObject player;
    







    void Start()
    {
    }

   
    void Update()
    {
        Openning_And_Closing();
        
    }

    void Openning_And_Closing()
    {
        if (Input.GetKeyDown("i"))
        {
            if (panel_Inventory_Manager.activeSelf == true)
            {
                panel_Inventory_Manager.SetActive(false);
            }
            else
            {
                panel_Inventory_Manager.SetActive(true);
            }
        }
    }

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

    public void EquipedItem(GameObject TECHE_Actual_Item)
    {
        
        player.GetComponent<CharacterWeapone>().AddStats(TECHE_Actual_Item);
    }

    public void ReEquipedItem()
    {
        player.GetComponent<CharacterWeapone>().LoadStats();


    }


}

