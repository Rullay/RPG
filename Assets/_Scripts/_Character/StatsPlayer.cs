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
    private int attackCleaving;

    private void Start()
    {
        SaveStats();
    }


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
            if(isAttackCleaving)
            {
                attackCleaving = 1;
            }
            else
            {
                attackCleaving = 0;
            }
        }

        if (TECH_Actual_Item.GetComponent<ItemArmor>() != null)
        {
           
            HealthMax = TECH_Actual_Item.GetComponent<ItemArmor>().STATS_armor_Health;
            StaminaMax = TECH_Actual_Item.GetComponent<ItemArmor>().STATS_armor_Stamina;
            StaminaReg = TECH_Actual_Item.GetComponent<ItemArmor>().STATS_armor_StaminaReg;
            MoveSpeed = TECH_Actual_Item.GetComponent<ItemArmor>().STATS_armor_MoveSpeed;
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

    void SaveStats()
    {
        PlayerPrefs.SetInt("STATS_weapone_Damage", AttackDamage);
        PlayerPrefs.SetFloat("STATS_ranage_Attack", AttackRange);
        PlayerPrefs.SetFloat("STATS_engle_of_Deafet", AttackAngle);
        PlayerPrefs.SetFloat("STATS_engle_of_Deafet", AttackAngle);
        PlayerPrefs.SetFloat("STATS_attack_Spped", AttackSpeed);


        PlayerPrefs.SetInt("STATS_armor_Health", HealthMax);
        PlayerPrefs.SetFloat("STATS_armor_Mana", StaminaMax);
        PlayerPrefs.SetFloat("STATS_armor_StanimaReg", StaminaReg);
        PlayerPrefs.SetFloat("STATS_armor_MoveSpeed", MoveSpeed);
    }

    public void LoadStats()
    {
        if (PlayerPrefs.HasKey("STATS_weapone_Damage"))
        {
            AttackDamage = PlayerPrefs.GetInt("STATS_weapone_Damage");
            AttackRange = PlayerPrefs.GetFloat("STATS_ranage_Attack");
            AttackAngle = PlayerPrefs.GetFloat("STATS_engle_of_Deafet");
            AttackSpeed = PlayerPrefs.GetFloat("STATS_attack_Spped");
            attackCleaving = PlayerPrefs.GetInt("STATS_is_Attack_Cleaving");
            if(attackCleaving == 1)
            {
                isAttackCleaving = true;
            }
            else
            {
                isAttackCleaving = false;
            }
            HealthMax = PlayerPrefs.GetInt("STATS_Health");
            StaminaMax = PlayerPrefs.GetFloat("STATS_Stamina");
            StaminaReg = PlayerPrefs.GetFloat("STATS_armor_StanimaReg");
            MoveSpeed = PlayerPrefs.GetFloat("STATS_armor_MoveSpeed");
        }
    }
}
