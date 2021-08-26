using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPlayer : Stats
{
    public int STATS_ExpPointHealth;
    public int STATS_ExpPointStamina;
    public int STATS_ExpPointSpeed;
    [SerializeField] private Slider TECH_HealthBar;

    public void AddItemStats(GameObject TECHE_Actual_Item)
    {
        if (TECHE_Actual_Item.GetComponent<ItemWeapone>() != null)
        {
            AttackDamage += TECHE_Actual_Item.GetComponent<ItemWeapone>().STATS_weapone_Damage;
            AttackRange += TECHE_Actual_Item.GetComponent<ItemWeapone>().STATS_ranage_Attack;
            AttackAngle += TECHE_Actual_Item.GetComponent<ItemWeapone>().STATS_engle_of_Deafet;
        }

        if (TECHE_Actual_Item.GetComponent<ItemArmor>() != null)
        {
           
            HealthMax += TECHE_Actual_Item.GetComponent<ItemArmor>().STATS_armor_Health;
            StaminaMax += TECHE_Actual_Item.GetComponent<ItemArmor>().STATS_armor_Mana;
        }
    }
    
    void HealthBar()
    {
        TECH_HealthBar.maxValue = HealthMax;
        TECH_HealthBar.value = HealthActual;
    } 
    
    public void UpStats(string NameState)
    {
        switch(NameState)
        {
            case "Stamina":
                STATS_ExpPointStamina++;
                break;
            case "Health":
                STATS_ExpPointHealth++;
                break;
            case "Speed":
                STATS_ExpPointSpeed++;
                break;
        }
    }

    /*void SaveStats()

    {
        PlayerPrefs.SetInt("STATS_weapone_Damage", STATS_AttackDamage);
        PlayerPrefs.SetFloat("STATS_ranage_Attack", STATS_AttackRange);
        PlayerPrefs.SetFloat("STATS_engle_of_Deafet", STATS_AttackAngle);
   
        PlayerPrefs.SetInt("STATS_armor_Health", STATS_HealthMax);
        PlayerPrefs.SetFloat("STATS_armor_Mana", STATS_StaminaMax);
    }

    public void LoadStats()
    {
        if (PlayerPrefs.HasKey("STATS_weapone_Damage"))
        {
            STATS_AttackDamage = PlayerPrefs.GetInt("STATS_weapone_Damage");
            STATS_AttackRange = PlayerPrefs.GetFloat("STATS_ranage_Attack");
            STATS_AttackAngle = PlayerPrefs.GetFloat("STATS_engle_of_Deafet");
        
            STATS_HealthMax = PlayerPrefs.GetInt("STATS_Health");
            STATS_StaminaMax = PlayerPrefs.GetFloat("STATS_Stamina");
        }
    }*/
}