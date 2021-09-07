using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPlayer : Stats
{
    public string AttackAnimation;
    [SerializeField] private Slider TECH_HealthBar;
    [SerializeField] private Slider TECH_StaminaBar;

    [Header("Base Stats")]
    [SerializeField] private float Base_StanimaReg;
    [SerializeField] private float Base_Stanima;
    [SerializeField] private float Base_MoveSpeed;
    [SerializeField] private int Base_Health;

    [Header("Exp Settings")]
    [SerializeField] private int experiencePlayer;
    [SerializeField] private int level = 1;
    [SerializeField] private int neededExperince;
    [SerializeField] private int upPoint;
    public int ExpPointHealth;
    public int ExpPointStamina;
    public int ExpPointSpeed;



    private void Start()
    {
        SaveStats();
        LoadStats();
    }

    public void Update()
    {
        StaminaCalculate();
        HealthCalculate();
        LevelUP();
    }

    public void AddItemStats(GameObject TECH_Actual_Item)
    {
        if (TECH_Actual_Item.GetComponent<ItemWeapone>() != null)
        {
            ItemWeapone TECH_ItemWeapone = TECH_Actual_Item.GetComponent<ItemWeapone>();

            AttackAnimation = TECH_ItemWeapone.GetWeaponAnimations();
            AttackDamage = TECH_ItemWeapone.STATS_weapone_Damage;
            AttackRange = TECH_ItemWeapone.STATS_ranage_Attack;
            AttackAngle = TECH_ItemWeapone.STATS_angle_of_Defeat;
            isAttackCleaving = TECH_ItemWeapone.STATS_is_Cleaving;
            AttackSpeed = TECH_ItemWeapone.STATS_attack_Speed;
        }

        if (TECH_Actual_Item.GetComponent<ItemArmor>() != null)
        {
            ItemArmor TECH_ItemArmor = TECH_Actual_Item.GetComponent<ItemArmor>();

            HealthMax += TECH_ItemArmor.STATS_armor_Health;
            StaminaMax += TECH_ItemArmor.STATS_armor_Stamina ;
            StaminaReg += TECH_ItemArmor.STATS_armor_StaminaReg;
            MoveSpeed += TECH_ItemArmor.STATS_armor_MoveSpeed;
        }
    }
    
    void HealthCalculate()
    {
        TECH_HealthBar.maxValue = HealthMax;
        TECH_HealthBar.value = HealthActual;
    } 

    void StaminaCalculate()
    {  
        if(StaminaActual < StaminaMax)
        {
            StaminaActual += StaminaReg * Time.deltaTime;
        }
        TECH_StaminaBar.maxValue = StaminaMax;
        TECH_StaminaBar.value = StaminaActual;
    }
    
    public void UpStats(string NameState)
    {
        if (upPoint > 0)
        {
            upPoint -= 1;
            switch (NameState)
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
            //SaveStats();
            //LoadStats();
        }
        
    }

    void LevelUP()
    {
        if (level == 1)
        {
            neededExperince = 100;
        }

        if (experiencePlayer >= neededExperince)
        {
            experiencePlayer -= neededExperince;
            level += 1;
            neededExperince = neededExperince + neededExperince / (10 + level) + level * 10 /*lavel/(10 + lavel)*/;
            upPoint += 3;
        }

    }

    void SaveStats()
    {
        PlayerPrefs.SetInt("ExpPointHealth", ExpPointHealth);
        PlayerPrefs.SetInt("ExpPointStamina", ExpPointStamina);
        PlayerPrefs.SetInt("ExpPointSpeed", ExpPointSpeed);
    }

    public void LoadStats()
    {
        if (PlayerPrefs.HasKey("STATS_weapone_Damage"))
        {
            ExpPointHealth = PlayerPrefs.GetInt("ExpPointHealth");
            ExpPointStamina = PlayerPrefs.GetInt("ExpPointStamina");
            ExpPointSpeed = PlayerPrefs.GetInt("ExpPointSpeed");
            HealthMax = Base_Health + ExpPointHealth * 5;
            StaminaMax = Base_Stanima + ExpPointStamina * 5;
            MoveSpeed = Base_MoveSpeed + ExpPointSpeed;
            StaminaReg = Base_StanimaReg;
        }
    }
}

