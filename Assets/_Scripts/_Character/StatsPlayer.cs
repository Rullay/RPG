using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPlayer : Stats
{
    public string AttackAnimation;
    [SerializeField] private Slider TECH_HealthBar;
    [SerializeField] private Slider TECH_StaminaBar;
    private int attackCleaving;

    [Header("Base Stats")]
    [SerializeField] private float Base_StanimaReg;
    [SerializeField] private float Base_Stanima;
    [SerializeField] private float Base_MoveSpeed;
    [SerializeField] private int Base_Health;

    [Header("Exp Settings")]
    [SerializeField] private int experiencePlayer;
    [SerializeField] private int lavel = 1;
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
        StaminaBar();
        HealthBar();
        if (Input.GetButtonDown("Jump"))
        {
            // получение опыта 
            experiencePlayer += 100;
        }
        LavelUP();
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
            HealthMax += TECH_Actual_Item.GetComponent<ItemArmor>().STATS_armor_Health;
            StaminaMax += TECH_Actual_Item.GetComponent<ItemArmor>().STATS_armor_Stamina ;
            StaminaReg += TECH_Actual_Item.GetComponent<ItemArmor>().STATS_armor_StaminaReg;
            MoveSpeed += TECH_Actual_Item.GetComponent<ItemArmor>().STATS_armor_MoveSpeed;
        }
    }
    
    void HealthBar()
    {
        TECH_HealthBar.maxValue = HealthMax;
        TECH_HealthBar.value = HealthActual;
    } 

    void StaminaBar()
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
            SaveStats();
            LoadStats();
            // переодевание шмоток
        }
        
    }

    void LavelUP()
    {
        if (lavel == 1)
        {
            neededExperince = 100;
        }

        if (experiencePlayer >= neededExperince)
        {
            experiencePlayer = experiencePlayer - neededExperince;
            lavel += 1;
            neededExperince = neededExperince + neededExperince / (10 + lavel) + lavel * 10 /*lavel/(10 + lavel)*/;
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
            // переодевание шмоток 
        }
    }
}

