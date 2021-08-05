using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapone : MonoBehaviour
{
    [SerializeField] private GameObject inventoryManager;

    //WeaponeStats
     public int STATS_weapone_Damage;
     public float STATS_ranage_Attack;
     public float STATS_engle_of_Deafet;

    void Start()
    {

    }


    void Update()
    {

    }

    public void AddStats(GameObject TECHE_Actual_Item)
    {
        Debug.Log(TECHE_Actual_Item.GetComponent<ItemWeapone>().STATS_weapone_Damage);

        STATS_weapone_Damage = TECHE_Actual_Item.GetComponent<ItemWeapone>().STATS_weapone_Damage;
        STATS_ranage_Attack = TECHE_Actual_Item.GetComponent<ItemWeapone>().STATS_ranage_Attack;
        STATS_engle_of_Deafet = TECHE_Actual_Item.GetComponent<ItemWeapone>().STATS_engle_of_Deafet;


    }
}
