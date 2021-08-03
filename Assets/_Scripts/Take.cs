using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : MonoBehaviour
{
    public GameObject current_Subject;
    [SerializeField] private GameObject inventory_Manager;


    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            current_Subject = other.gameObject;
            inventory_Manager.GetComponent<InventoryManager>().ItemDispenser();
            other.GetComponent<Item>().Ñollected();
        }
    }
}
