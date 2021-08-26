using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    private readonly List<GameObject> TECH_TriggerWorldObjectList = new List<GameObject>();
    private GameObject TECH_TargetObject;

    void Update()
    {
        TECH_TargetObject = null;

        foreach (GameObject ActivateObject in TECH_TriggerWorldObjectList)
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

    public void ActivateTargetObject()
    {
        if (TECH_TargetObject)
        {
            TECH_TargetObject.GetComponent<WorldObject>().Activate();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other!.GetComponent<WorldObject>())
        {
            TECH_TriggerWorldObjectList.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other!.GetComponent<WorldObject>())
        {
            TECH_TriggerWorldObjectList.Remove(other.gameObject);
        }
    }
}
