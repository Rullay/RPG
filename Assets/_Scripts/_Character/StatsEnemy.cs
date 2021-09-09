using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsEnemy : StatsCharacter
{
    [SerializeField] private int ExpPerDeath;


    [SerializeField] private float STATS_StaminaMax;
    [SerializeField] private float STATS_StaminaReg;
    [SerializeField] private int STATS_HealthMax;
    [SerializeField] private int STATS_AttackDamage;
    [SerializeField] private float STATS_AttackRange;
    [SerializeField] private float STATS_AttackAngle;
    [SerializeField] private float STATS_AttackSpeed;
    [SerializeField] private bool STATS_isAttackCleaving;

    private enum AnimationType
    {
        OneHand,
        TwoHand,
        Bow,
        Staff,
        Shield
    }
    [SerializeField] private AnimationType STATS_AttackAnimation;

    private void Start()
    {
        EnemyStatsInicialize();
    }

    void EnemyStatsInicialize()
    {
        StaminaMax = STATS_StaminaMax;
        StaminaReg = STATS_StaminaReg;
        HealthMax = STATS_HealthMax;
        AttackDamage = STATS_AttackDamage;
        AttackRange = STATS_AttackRange;
        AttackAngle = STATS_AttackAngle;
        AttackSpeed = STATS_AttackSpeed;
        isAttackCleaving = STATS_isAttackCleaving;

        switch (STATS_AttackAnimation)
        {
            case AnimationType.OneHand:
                AttackAnimation = "OneHand";
                break;
            case AnimationType.TwoHand:
                AttackAnimation = "TwoHand";
                break;
            case AnimationType.Bow:
                AttackAnimation = "Bow";
                break;
            case AnimationType.Staff:
                AttackAnimation = "Staff";
                break;
            case AnimationType.Shield:
                AttackAnimation = "Shield";
                break;
        }
    }
}
