using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character
{
    [Header("Move")]
    public float STATS_MoveSpeed;
    public float STATS_MoveRunMultiplier;
    public float STATS_JupmSpeed;
    public float STATS_Gravity;

    [Header("Health")]
    public float STATS_HealthMax;
    public float STATS_HealthActual
    {
        get { return STATS_HealthActual; }
        set
        {
            STATS_HealthActual = Mathf.Clamp(value, 0, STATS_HealthMax);
            if(STATS_HealthActual <= 0)
            {
                //Dead
            }
        }
    }

    [Header("Stamina")]
    public float STATS_StaminaMax;
    public float STATS_StaminaActual;

    [Header("Attack")]
    public float STATS_AttackDamage;
    public float STATS_AttackRange;
    public float STATS_AttackSpeed;
}
