using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //Panel
    [SerializeField] private GameObject panel_Inventory_Manager;
    [SerializeField] private List<GameObject> inventory_Types;
    







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
           /* Debug.Log(ItemObject.GetComponent<Item>().item_Type);
            Debug.Log(inventory_Types[i].GetComponent<InventoryItem>().slot_Type);*/
            if (ItemObject.GetComponent<Item>().item_Type == inventory_Types[i].GetComponent<InventoryItem>().slot_Type)
           {
                //Debug.Log(i);
                inventory_Types[i].GetComponent<InventoryItem>().items.Add(ItemObject);
           }
        }
        
    }




}

