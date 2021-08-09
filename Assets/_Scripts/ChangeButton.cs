using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButton : MonoBehaviour
{
    [SerializeField] private List<GameObject> Hands_1;
    [SerializeField] private List<GameObject> Hands_2;
    [SerializeField] private GameObject inventoryManager;


   void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void ChangeHands()
    {
        if(Hands_1[0].activeSelf == true)
        {
            for(int i = 0; i < Hands_2.Count; i++)
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
        inventoryManager.GetComponent<InventoryManager>().ReEquipedItem();
    }
}
