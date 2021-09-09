using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsCharacter : MonoBehaviour
{

    public enum STATE { Alive, Dead }
    public STATE TECH_State = STATE.Alive;

    private void Start()
    {
        TECH_State = STATE.Alive;
        HealthActual = HealthMax;
        StaminaActual = StaminaMax;
    }

    [Header("Move")]
    public float MoveSpeed;
    public float MoveRunMultiplier;
    public float JupmSpeed;
    public float Gravity;

    [Header("Health")]
    public int HealthMax;
    public int HealthActual;

    [Header("Stamina")]
    public float StaminaMax;
    public float StaminaActual;
    public float StaminaReg;

    [Header("Attack")]
    public int AttackDamage;
    public float AttackRange;
    public float AttackAngle;
    public float AttackSpeed;
    public bool isAttackCleaving;
    public string AttackAnimation;

    public void TakeDamage(int TECH_DamageValue)
    {
        HealthActual = Mathf.Clamp(HealthActual - TECH_DamageValue, 0, HealthMax);
        if (HealthActual <= 0)
        {
            TECH_State = STATE.Dead;
        }
    }
}
