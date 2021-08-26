using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject Arrow;

    private List<GameObject> TECH_TriggerEnemyList;
    private GameObject TECH_ClosestEnemy;
    private float TECH_ClosestEnemyRange;

    private RaycastHit TECH_CameraHit;



    private void OnTriggerEnter(Collider other)
    {
        if (other!.GetComponent<Stats>())
        {
            TECH_TriggerEnemyList.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other!.GetComponent<Stats>())
        {
            TECH_TriggerEnemyList.Remove(other.gameObject);
        }
    }



    public void MeleeAttack(int Damage, float Angle, float Range, bool isCleaving)
    {
        //PlayAttackAnimation(STATS_AttackSpeed);

        SetAttackRange(Range);

        TECH_ClosestEnemy = null;

        if (TECH_TriggerEnemyList.Count != 0)
        {
            foreach (GameObject Object in TECH_TriggerEnemyList)
            {
                if (Mathf.Abs(Vector3.Angle(Object.transform.position - transform.position, transform.forward)) < Angle * 0.5f)
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

            if (isCleaving)
            {
                foreach (GameObject Object in TECH_TriggerEnemyList)
                {
                    Object.GetComponent<Stats>().TakeDamage(Damage);
                }
            }
            else if (TECH_ClosestEnemy)
            {
                TECH_ClosestEnemy.GetComponent<Stats>().TakeDamage(Damage);
            }
        }
    }

    public void RangeAttack(int Damage, GameObject Arrow)
    {
        //PlayAttackAnimation(STATS_AttackSpeed);
        GameObject ArrowObject = Instantiate<GameObject>(Arrow, transform.position, Quaternion.Euler(Vector3.zero));
        ArrowObject.GetComponent<TECH_Arrow>().Initialized(gameObject, TECH_CalculateDirectionVector(), Damage);
    }

    public void SetAttackRange(float Range)
    {
        transform.localScale = new Vector3(Range + 0.5f, 1, 1);
    }

    // TECH ///////////////////////////////

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