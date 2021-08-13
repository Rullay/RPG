using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CharacterPlayer
{
    private GameObject TECH_TargetObject;
    private GameObject TECH_TriggerObject;
    private List<GameObject> TECH_ActivateObject;

    void ActivateTargetObject()
    {
        if (TECH_TargetObject)
        {
            TECH_TargetObject.GetComponent<WorldObject>().Activate();
        }
    }

    void UpdateObjectInTarget()
    {
        TECH_TargetObject = null;
        TECH_ActivateObject = TECH_TriggerObject.GetComponent<TECH_ActivateTrigger>().TECH_TriggerWorldObjectList;

        foreach (GameObject ActivateObject in TECH_ActivateObject)
        {
            if (!TECH_TargetObject)
            {
                TECH_TargetObject = ActivateObject;
            }
            else if ((TECH_TargetObject.transform.position - transform.position).magnitude > (ActivateObject.transform.position - transform.position).magnitude)
            {
                TECH_TargetObject = ActivateObject;
            }
        }
    }

    void InitializedActivate()
    {
        foreach (Transform TECH_Child in transform)
        {
            if (TECH_Child!.GetComponent<TECH_ActivateTrigger>())
            {
                TECH_TriggerObject = TECH_Child.gameObject;
            }
        }
    }
}
