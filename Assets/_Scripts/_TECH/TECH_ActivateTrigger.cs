using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TECH_ActivateTrigger : MonoBehaviour
{
    public List<GameObject> TECH_TriggerList = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (other!.GetComponent<WorldObject>())
        {
            TECH_TriggerList.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other!.GetComponent<WorldObject>())
        {
            TECH_TriggerList.Remove(other.gameObject);
        }
    }
}
