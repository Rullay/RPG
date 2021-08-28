using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPlayer : Stats
{
    public int ExpPointHealth;
    public int ExpPointStamina;
    public int ExpPointSpeed;
    public string AttackAnimation;
    [SerializeField] private Slider TECH_HealthBar;

    public void AddItemStats(GameObject TECH_Actual_Item)
    {
        if (TECH_Actual_Item.GetComponent<ItemWeapone>() != null)
        {
            AttackAnimation = TECH_Actual_Item.GetComponent<ItemWeapone>().animation_Type;
            AttackDamage = TECH_Actual_Item.GetComponent<ItemWeapone>().STATS_weapone_Damage;
            AttackRange = TECH_Actual_Item.GetComponent<ItemWeapone>().STATS_ranage_Attack;
            AttackAngle = TECH_Actual_Item.GetComponent<ItemWeapone>().STATS_engle_of_Deafet;
            isAttackCleaving = TECH_Actual_Item.GetComponent<ItemWeapone>().STATS_is_Cleaving;
            AttackSpeed = TECH_Actual_Item.GetComponent<ItemWeapone>().STATS_attack_Speed;
        }

        if (TECH_Actual_Item.GetComponent<ItemArmor>() != null)
        {
           
            HealthMax += TECH_Actual_Item.GetComponent<ItemArmor>().STATS_armor_Health;
            StaminaMax += TECH_Actual_Item.GetComponent<ItemArmor>().STATS_armor_Mana;
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
                ExpPointStamina++;
                break;
            case "Health":
                ExpPointHealth++;
                break;
            case "Speed":
                ExpPointSpeed++;
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
