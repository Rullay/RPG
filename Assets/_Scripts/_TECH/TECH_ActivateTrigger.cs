using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TECH_ActivateTrigger : MonoBehaviour
{
    public List<GameObject> TECH_TriggerWorldObjectList;

    private void OnTriggerEnter(Collider other)
    {
        if (other!.GetComponent<WorldObject>())
        {
            TECH_TriggerWorldObjectList.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other!.GetComponent<WorldObject>())
        {
            TECH_TriggerWorldObjectList.Remove(other.gameObject);
        }
    }
}
