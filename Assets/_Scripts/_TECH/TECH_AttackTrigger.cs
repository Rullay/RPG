using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TECH_AttackTrigger : MonoBehaviour
{
    public List<GameObject> TECH_TriggerEnemyList = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (other!.GetComponent<StatsCharacter>())
        {
            TECH_TriggerEnemyList.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other!.GetComponent<StatsCharacter>())
        {
            TECH_TriggerEnemyList.Remove(other.gameObject);
        }
    }
}
