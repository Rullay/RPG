using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TECH_Arrow : MonoBehaviour
{
    [SerializeField] private float STATS_FlySpeed;
    [SerializeField] private float STATS_GravitySpeed;
    [SerializeField] private float SET_LifetimeAfterHit;
    [SerializeField] private float SET_LifetimeAfterShot;

    private int STATS_Damage;

    private GameObject TECH_Owner;
    private Vector3 TECH_FlyDirection;
    private float TECH_LifetimeAfterHit;
    private float TECH_LifetimeAfterShot;
    private bool TECH_isFly;
    private Vector3 TECH_PastPosition;

    void Update()
    {
        if (SET_LifetimeAfterShot < TECH_LifetimeAfterShot || SET_LifetimeAfterHit < TECH_LifetimeAfterHit)
        {
            Destroy(gameObject);
        }
        else if (TECH_isFly)
        {
            transform.position += TECH_FlyDirection.normalized * STATS_FlySpeed * Time.deltaTime;
            transform.LookAt(2 * transform.position - TECH_PastPosition);
        }
        else
        {
            TECH_LifetimeAfterHit += Time.deltaTime;
        }

        TECH_LifetimeAfterShot += Time.deltaTime;
        TECH_FlyDirection -= new Vector3(0, STATS_GravitySpeed * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != TECH_Owner && !other.isTrigger)
        {

            if (other.GetComponent<StatsCharacter>())
            {
                transform.SetParent(other.transform);
                other.GetComponent<StatsCharacter>().TakeDamage(STATS_Damage);
            }
            TECH_isFly = false;
        }
    }

    public void Initialized(GameObject Owner, Vector3 FlyDirection, int Damage)
    {
        STATS_Damage = Damage;

        TECH_FlyDirection = FlyDirection;
        TECH_Owner = Owner;
        TECH_isFly = true;
        TECH_PastPosition = transform.position;
    }
}
