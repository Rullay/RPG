using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllerEnemy : MonoBehaviour
{
    private enum STATE_AI { Patrol, GoToPatrol, Find, GoToAttack, Attack, AttackWait }
    private STATE_AI TECH_StateAI;

    private GameObject Target;
    private Transform TargetTransform;
    private Vector3 TECH_StartPosition;
    private RaycastHit TECH_TargetHit;

    [Header("AI")]
    [SerializeField] private float STATS_DetectionRange;
    [SerializeField] private float STATS_VisionRange;

    private NavMeshAgent NMA;
    private StatsEnemy Stats;
    private Attack Attack;
    private AnimationManager AnimationManager;

    void Start()
    {
        AnimationManager = GetComponent<AnimationManager>();
        Stats = GetComponent<StatsEnemy>();
        NMA = GetComponent<NavMeshAgent>();
        Attack = GetComponent<Attack>();

        Target = GameManager.Instance.Player;
        TargetTransform = Target.transform;
        TECH_StartPosition = transform.position;

        NMA.speed = Stats.MoveSpeed;
    }

    void Update()
    {
        if (Stats.TECH_State == StatsCharacter.STATE.Alive)
        {
            switch (TECH_StateAI)
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
                case STATE_AI.AttackWait:
                    AI_AttackWait();
                    break;
            }
        } else
        {
            NMA.isStopped = true;
        }
    }

    void AI_Patrol()
    {
        if ((TECH_GetDistanceTo(TargetTransform.position) < STATS_DetectionRange) && TECH_IsSeePlayer())
        {
            TECH_StateAI = STATE_AI.GoToAttack;
        }
    }

    void AI_GoToPatrol()
    {
        NMA.SetDestination(TECH_StartPosition);
        TECH_StateAI = STATE_AI.Patrol;
    }

    void AI_Find()
    {
        if (TECH_IsSeePlayer())
        {
            TECH_StateAI = STATE_AI.GoToAttack;
        }
        else if (NMA.remainingDistance < 0.1f)
        {
            TECH_StateAI = STATE_AI.GoToPatrol;
        }
    }

    void AI_Attack()
    {
        if (!Attack.isAttack())
        {
            Attack.PlayAttack(Stats.AttackDamage, Stats.AttackAngle, Stats.AttackRange, Stats.isAttackCleaving, Stats.AttackSpeed);
            AnimationManager.PlayAttackAnimation(Stats.AttackAnimation);
        }
        TECH_StateAI = STATE_AI.AttackWait;
    }

    void AI_AttackWait()
    {
        if (!Attack.isAttack())
        {
            TECH_StateAI = STATE_AI.GoToAttack;
        }
    }

    void AI_GoToAttack()
    {
        if (TECH_GetDistanceTo(TargetTransform.position) < Stats.AttackRange * 0.8f)
        {
            TECH_StateAI = STATE_AI.Attack;
        }
        else if (TECH_IsSeePlayer())
        {
            NMA.SetDestination(TargetTransform.position);
        }
        else
        {
            TECH_StateAI = STATE_AI.Find;
        }
    }


    float TECH_GetDistanceTo(Vector3 Point)
    {
        return (Point - transform.position).magnitude;
    }

    bool TECH_IsSeePlayer()
    {
        if (Physics.Raycast(transform.position + new Vector3(0f,transform.localScale.y * 0.8f,0f), TargetTransform.position - transform.position,out TECH_TargetHit,STATS_VisionRange))
        {
            if (TECH_TargetHit.collider.gameObject == Target)
            {
                return true;
            }
        }
        return false;
    }
}
