using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character
{
    protected GameObject TECH_Model;
    [SerializeField] private List<GameObject> TEHC_MainHands;
    [SerializeField] protected Animator Animator;
    private int Set_Actual_MainHands;
    private float TECH_AnimationTime;
    private float Set_SpeedRatio;

    public bool isAttack;
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
          
            for (int i = 0; i < TEHC_MainHands.Count; i++)
            {
               
                if (TEHC_MainHands[i].activeSelf == true && TEHC_MainHands[i].GetComponent<InventoryItem>().equipedItemObject != null)
                {
                    TEHC_MainHands[i].GetComponent<InventoryItem>().equipedItemObject.GetComponent<Item>().WriteAnimationType();

                    Set_SpeedRatio = 60 * STATS_AttackSpeed;
                    Set_SpeedRatio = 60 / Set_SpeedRatio;

                    Animator.SetFloat("SpeedAnimation", Set_SpeedRatio);

                    TECH_AnimationTime = STATS_AttackSpeed;

                    switch (TEHC_MainHands[i].GetComponent<InventoryItem>().equipedItemObject.GetComponent<Item>().animation_Type)
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
                    Set_Actual_MainHands = i;
                    isAttack = true;
                    StartCoroutine(StopAttackAnimation());
                }
            }      
        }
    }
    IEnumerator StopAttackAnimation()
    {
        yield return new WaitForSeconds(TECH_AnimationTime);
        isAttack = false;
        switch (TEHC_MainHands[Set_Actual_MainHands].GetComponent<InventoryItem>().equipedItemObject.GetComponent<Item>().animation_Type)
        {
            case "OneHand":
                Animator.SetBool("OneHandAttack", false);
                break;
            case "TwoHand":
                Animator.SetBool("TwoHandAttack", false);
                break;
            case "Bow":
                Animator.SetBool("ModelBowAttack", false);
                break;
            case "Staff":
                Animator.SetBool("ModelStaffAttack", false);
                break;
        }
    }
}
