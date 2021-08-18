using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character
{
    private GameObject ColliderObject;
    private List<GameObject> TECH_TriggerEnemyList;
    private GameObject TECH_ClosestEnemy;
    private float TECH_ClosestEnemyRange;

    private RaycastHit TECH_CameraHit;

    void InitializedAttack()
    {
        foreach (Transform TECH_Child in transform)
        {
            if (TECH_Child!.GetComponent<TECH_AttackTrigger>())
            {
                ColliderObject = TECH_Child.gameObject;
            }
        }
        if (!ColliderObject)
        {
            Debug.LogWarning("!!! Не найден объект с триггером попадания !!!");
        }

        TECH_RecalculateCollider();
    }

    protected void Attack()
    {
        isAttack = true;

        TECH_ClosestEnemy = null;
        TECH_TriggerEnemyList = ColliderObject.GetComponent<TECH_AttackTrigger>().TECH_TriggerEnemyList;
        TECH_TriggerEnemyList.Remove(gameObject);

        if (TECH_TriggerEnemyList.Count != 0)
        {
            foreach (GameObject Object in TECH_TriggerEnemyList)
            {
                if (Mathf.Abs(Vector3.Angle(Object.transform.position - TECH_Model.transform.position, TECH_Model.transform.forward)) < STATS_AttackAngle * 0.5f)
                {
                    if (!TECH_ClosestEnemy)
                    {
                        TECH_SetClosestEnemy(Object);
                    }
                    else if (TECH_ClosestEnemyRange < (Object.transform.position - transform.position).magnitude)
                    {
                        TECH_SetClosestEnemy(Object);
                    }
                }
            }

            if (STATS_isAttackCleaving)
            {
                foreach (GameObject Object in TECH_TriggerEnemyList)
                {
                    Object.GetComponent<Character>().GetDamage(STATS_AttackDamage);
                }
            }
            else if (TECH_ClosestEnemy)
            {
                TECH_ClosestEnemy.GetComponent<Character>().GetDamage(STATS_AttackDamage);
            }
        }
    }

    protected void RangeAttack(GameObject Arrow)
    {
        GameObject ArrowObject = Instantiate<GameObject>(Arrow, transform.position, Quaternion.Euler(Vector3.zero));
        ArrowObject.GetComponent<TECH_Arrow>().Initialized(gameObject, TECH_CalculateDirectionVector(), STATS_AttackDamage);
    }

    void TECH_RecalculateCollider()
    {
        ColliderObject.transform.localScale = new Vector3(STATS_AttackRange + 0.5f, 1, 1);
    }

    void TECH_SetClosestEnemy(GameObject Object)
    {
        TECH_ClosestEnemy = Object;
        TECH_ClosestEnemyRange = (Object.transform.position - transform.position).magnitude;
    }

    Vector3 TECH_CalculateDirectionVector()
    {
        if(Physics.Raycast(transform.position, GameManager.Instance.Camera.transform.forward, out TECH_CameraHit, Mathf.Infinity))
        {
            return (TECH_CameraHit.point - transform.position);
        }
        else
        {
            return GameManager.Instance.Camera.transform.forward;
        }
    }
}