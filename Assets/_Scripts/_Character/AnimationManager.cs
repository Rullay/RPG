using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    protected GameObject TECH_Model;
    [SerializeField] private List<GameObject> TECH_MainHands;
    private Animator Animator;

    private bool isAttack;
    protected bool isJump;

    void Start()
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

    public void SetMoveHorizontalVector(Vector3 Vector)
    {
        Animator.SetFloat("Speed", Vector.magnitude);
    }

    public void PlayAttackAnimation(float AttackSpeed)
    {
        if (isAttack == false)
        {
            for (int i = 0; i < TECH_MainHands.Count; i++)
            {
                if (TECH_MainHands[i].activeSelf == true && TECH_MainHands[i].GetComponent<InventoryItem>().equipedItemObject != null)
                {
                    TECH_MainHands[i].GetComponent<InventoryItem>().equipedItemObject.GetComponent<Item>().WriteAnimationType();

                    Animator.SetFloat("SpeedAnimation", 1 / AttackSpeed);

                    switch (TECH_MainHands[i].GetComponent<InventoryItem>().equipedItemObject.GetComponent<Item>().animation_Type)
                    {
                        case "OneHand":
                            Animator.SetBool("OneHandAttack", true);
                            break;
                        case "TwoHand":
                            Animator.SetBool("TwoHandAttack", true);
                            break;
                        case "Bow":
                            Animator.SetBool("BowAttack", true);
                            break;
                        case "Staff":
                            Animator.SetBool("StaffAttack", true);
                            break;
                    }

                    isAttack = true;
                    StartCoroutine(StopAttackAnimation(AttackSpeed));
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
        Animator.SetBool("BowAttack", false);
        Animator.SetBool("StaffAttack", false);
    }
}