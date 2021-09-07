using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemArmor : Item
{
    public int STATS_armor_Health;
    public float STATS_armor_Stamina;
    public float STATS_armor_StaminaReg;
    public float STATS_armor_MoveSpeed;

    new void Start()
    {
        base.Start();
    }
}
