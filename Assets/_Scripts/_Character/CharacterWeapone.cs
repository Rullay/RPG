using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character
{
    [SerializeField] private GameObject inventoryManager;

    public int STATS_weapone_Damage;
    public float STATS_ranage_Attack;
    public float STATS_engle_of_Deafet;
    public int STATS_armor_Armor;
    public int STATS_armor_Health;
    public int STATS_armor_Mana;

    public void AddStats(GameObject TECHE_Actual_Item)
    {
        if (TECHE_Actual_Item.GetComponent<ItemWeapone>() != null)
        {
            STATS_weapone_Damage += TECHE_Actual_Item.GetComponent<ItemWeapone>().STATS_weapone_Damage;
            STATS_ranage_Attack += TECHE_Actual_Item.GetComponent<ItemWeapone>().STATS_ranage_Attack;
            STATS_engle_of_Deafet += TECHE_Actual_Item.GetComponent<ItemWeapone>().STATS_engle_of_Deafet;
        }

        if (TECHE_Actual_Item.GetComponent<ItemArmor>() != null)
        {
            STATS_armor_Armor += TECHE_Actual_Item.GetComponent<ItemArmor>().STATS_armor_Armor;
            STATS_armor_Health += TECHE_Actual_Item.GetComponent<ItemArmor>().STATS_armor_Health;
            STATS_armor_Mana += TECHE_Actual_Item.GetComponent<ItemArmor>().STATS_armor_Mana;
        }



    }


    void SaveStats()
    {
        PlayerPrefs.SetInt("STATS_weapone_Damage", STATS_weapone_Damage);
        PlayerPrefs.SetFloat("STATS_ranage_Attack", STATS_ranage_Attack);
        PlayerPrefs.SetFloat("STATS_engle_of_Deafet", STATS_engle_of_Deafet);
        PlayerPrefs.SetInt("STATS_armor_Armor", STATS_armor_Armor);
        PlayerPrefs.SetInt("STATS_armor_Health", STATS_armor_Health);
        PlayerPrefs.SetInt("STATS_armor_Mana", STATS_armor_Mana);
    }
    public void LoadStats()
    {
        if (PlayerPrefs.HasKey("STATS_weapone_Damage"))
        {
            STATS_weapone_Damage = PlayerPrefs.GetInt("STATS_weapone_Damage");
            STATS_ranage_Attack = PlayerPrefs.GetFloat("STATS_ranage_Attack");
            STATS_engle_of_Deafet = PlayerPrefs.GetFloat("STATS_engle_of_Deafet");
            STATS_armor_Armor = PlayerPrefs.GetInt("STATS_armor_Armor");
            STATS_armor_Health = PlayerPrefs.GetInt("STATS_armor_Health");
            STATS_armor_Mana = PlayerPrefs.GetInt("STATS_armor_Mana");
        }
    }
}
