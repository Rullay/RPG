using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character
{
    protected GameObject TECH_Model;
    [SerializeField] private List<GameObject> TECH_MainHands;
    private Animator Animator;

    private bool isAttack;
    protected bool isJump;

    void InitializedModel()
    {
        foreach (Transform TECH_Child in transform)
        {
            if (TECH_Child.GetComponent<TECH_ModelHumanoid>())
            {
                TECH_Model = TECH_Child.gameObject;
                Animator = TECH_Model.GetComponent<Animator>();
            }
        }
        if (!TECH_Model)
        {
            Debug.LogWarning("!!! Не найдена модель объекта !!!");
            TECH_Model = gameObject;
        }
    }

    protected void SetMoveHorizontalVector(Vector3 Vector)
    {
        Animator.SetFloat("Speed", Vector.magnitude);
    }

    protected void AttackAnimation()
    {
        if (isAttack == false)
        {
            for (int i = 0; i < TECH_MainHands.Count; i++)
            {
                if (TECH_MainHands[i].activeSelf == true && TECH_MainHands[i].GetComponent<InventoryItem>().equipedItemObject != null)
                {
                    TECH_MainHands[i].GetComponent<InventoryItem>().equipedItemObject.GetComponent<Item>().WriteAnimationType();

                    Animator.SetFloat("SpeedAnimation", 1 / STATS_AttackSpeed);

                    switch (TECH_MainHands[i].GetComponent<InventoryItem>().equipedItemObject.GetComponent<Item>().animation_Type)
                    {
                        case "OneHand":
                            Animator.SetBool("OneHandAttack", true);
                            break;
                        case "TwoHand":
                            Animator.SetBool("TwoHandAttack", true);
                            break;
                        case "Bow":
                            Animator.SetBool("ModelBowAttack", true);
                            break;
                        case "Staff":
                            Animator.SetBool("ModelStaffAttack", true);
                            break;
                    }

                    isAttack = true;
                    StartCoroutine(StopAttackAnimation(STATS_AttackSpeed));
                }
            }
        }
    }

    IEnumerator StopAttackAnimation(float AnimationTime)
    {
        yield return new WaitForSeconds(AnimationTime);
        isAttack = false;
        Animator.SetBool("OneHandAttack", false);
        Animator.SetBool("TwoHandAttack", false);
        Animator.SetBool("ModelBowAttack", false);
        Animator.SetBool("ModelStaffAttack", false);
    }
}
