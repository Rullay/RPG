using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemWeapone : Item
{
    public int STATS_weapone_Damage;
    public float STATS_ranage_Attack;
    public float STATS_angle_of_Defeat;
    public float STATS_attack_Speed;
    public bool STATS_is_Cleaving;

    private enum AnimationType
    {
        OneHand,
        TwoHand,
        Bow,
        Staff,
        Shield
    }
    [SerializeField] private AnimationType animationType;
    private string TECH_AnimationType;

    public override void Start()
    {
        base.Start();
        WriteAnimationType();
    }

    void WriteAnimationType()
    {
        switch (animationType)
        {
            case AnimationType.OneHand:
                TECH_AnimationType = "OneHand";
                break;
            case AnimationType.TwoHand:
                TECH_AnimationType = "TwoHand";
                break;
            case AnimationType.Bow:
                TECH_AnimationType = "Bow";
                break;
            case AnimationType.Staff:
                TECH_AnimationType = "Staff";
                break;
            case AnimationType.Shield:
                TECH_AnimationType = "Shield";
                break;
        }
    }

    public string GetWeaponAnimations()
    {
        return TECH_AnimationType;
    }
}
