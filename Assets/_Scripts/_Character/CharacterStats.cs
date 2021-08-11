using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character
{

    protected enum STATE { Alive, Dead }
    protected STATE TECH_State = STATE.Alive;

    [Header("Move")]
    public float STATS_MoveSpeed;
    public float STATS_MoveRunMultiplier;
    public float STATS_JupmSpeed;
    public float STATS_Gravity;

    [Header("Health")]
    public int STATS_HealthMax;
    public int STATS_HealthActual;

    [Header("Stamina")]
    public float STATS_StaminaMax;
    public float STATS_StaminaActual;

    [Header("Attack")]
    public int STATS_AttackDamage;
    public float STATS_AttackRange;
    public float STATS_AttackAngle;
    public float STATS_AttackSpeed;
    public bool STATS_isAttackCleaving;

    public void GetDamage(int TECH_DamageValue)
    {
        STATS_HealthActual = Mathf.Clamp(STATS_HealthActual - TECH_DamageValue, 0, STATS_HealthMax);
        if (STATS_HealthActual <= 0)
        {
            TECH_State = STATE.Dead;
        }
    }

    public void TECH_ReCalculateStats()
    {

    }

    void InitializedStats()
    {
        TECH_State = STATE.Alive;
        STATS_HealthActual = STATS_HealthMax;
        STATS_StaminaActual = STATS_StaminaMax;
    }

 
}
