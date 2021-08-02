using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private GameObject itemSlot;
    public bool clik;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Clik()
    {
        clik = true;
        itemSlot.GetComponent<InventoryItem>().Equiped();
        clik = false;
    }
}
