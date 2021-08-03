using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //Panel
    [SerializeField] private GameObject panel_Inventory_Manager;
    /*[SerializeField] private GameObject panel_Inventory_Item;
    [SerializeField] private GameObject panel_Head_Item;
    [SerializeField] private GameObject panel_Chest_Item;
    [SerializeField] private GameObject panel_RightHand_Item;
    [SerializeField] private GameObject panel_LeftHand_Item;
    [SerializeField] private GameObject panel_Artifact_1_Item;
    [SerializeField] private GameObject panel_Artifact_2_Item;*/




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

    


}

