using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character
{
    protected GameObject TECH_Model;

    void InitializedModel()
    {
        foreach (Transform TECH_Child in transform)
        {
            if (TECH_Child.GetComponent<TECH_ModelHumanoid>())
            {
                TECH_Model = TECH_Child.gameObject;
            }
        }
        if (!TECH_Model)
        {
            TECH_Model = gameObject;
        }
    }
}
