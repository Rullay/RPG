using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterEnemyAI : Character
{
    private enum STATE_AI { Patrol, GoToPatrol, Find, GoToAttack, Attack }
    private STATE_AI TECH_State;

    private NavMeshAgent NMA;
    private GameObject Target;
    private Transform TargetTransform;
    private Vector3 TECH_StartPosition;
    private RaycastHit TECH_TargetHit;

    [Header("AI")]
    [SerializeField] private float STATS_DetectionRange;
    [SerializeField] private float STATS_VisionRange;

    void Start()
    {
        Target = GameManager.Instance.Player;

        TargetTransform = Target.transform;
        TECH_StartPosition = transform.position;
        NMA = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        switch(TECH_State)
        {
            case STATE_AI.Patrol:
                AI_Patrol();
                break;
            case STATE_AI.GoToPatrol:
                AI_GoToPatrol();
                break;
            case STATE_AI.Find:
                AI_Find();
                break;
            case STATE_AI.Attack:
                AI_Attack();
                break;
            case STATE_AI.GoToAttack:
                AI_GoToAttack();
                break;
        }
    }

    void AI_Patrol()
    {
        if ((TECH_GetDistanceTo(TargetTransform.position) < STATS_DetectionRange) && TECH_IsSeePlayer())
        {
            TECH_State = STATE_AI.GoToAttack;
        }
    }

    void AI_GoToPatrol()
    {
        NMA.SetDestination(TECH_StartPosition);
        TECH_State = STATE_AI.Patrol;
    }

    void AI_Find()
    {
        if (TECH_IsSeePlayer())
        {
            TECH_State = STATE_AI.GoToAttack;
        }
        else if (NMA.remainingDistance < 0.1f)
        {
            TECH_State = STATE_AI.GoToPatrol;
        }
    }

    void AI_Attack()
    {
        Debug.Log("Attack");
        TECH_State = STATE_AI.GoToAttack;
    }

    void AI_GoToAttack()
    {
        if (TECH_GetDistanceTo(TargetTransform.position) < STATS_AttackRange)
        {
            TECH_State = STATE_AI.Attack;
        }
        else if (TECH_IsSeePlayer())
        {
            NMA.SetDestination(TargetTransform.position);
        }
        else
        {
            TECH_State = STATE_AI.Find;
        }
    }


    float TECH_GetDistanceTo(Vector3 Point)
    {
        return (Point - transform.position).magnitude;
    }

    bool TECH_IsSeePlayer()
    {
        if (Physics.Raycast(transform.position, TargetTransform.position - transform.position,out TECH_TargetHit,STATS_VisionRange))
        {
            if(TECH_TargetHit.collider.gameObject == Target)
            {
                return true;
            }
        }
        return false;
    }
}
