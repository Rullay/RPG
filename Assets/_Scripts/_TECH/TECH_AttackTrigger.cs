using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TECH_AttackTrigger : MonoBehaviour
{
    public List<GameObject> TECH_TriggerEnemyList;
    public List<GameObject> TECH_TriggerList;

    private void OnTriggerEnter(Collider other)
    {
        if (other!.GetComponent<Character>())
        {
            TECH_TriggerEnemyList.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other!.GetComponent<Character>())
        {
            TECH_TriggerEnemyList.Remove(other.gameObject);
        }
    }
}
