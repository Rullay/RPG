using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character
{
    protected GameObject TECH_Model;
    [SerializeField] protected Animator Animator;

    protected bool isAttack;
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

    void UpdateAnimation()
    {
        if (isAttack == true)
        {
            Debug.Log("yebal");
            Animator.SetBool("Attack", true);
            
            StartCoroutine(StopAttack());           
           
        }
        
        IEnumerator StopAttack()
        {
            
            yield return new WaitForSeconds(1f);               
            Animator.SetBool("Attack", false);
            isAttack = false;
        }
        
       // Animator.SetBool("Jump", isJump);
    }
}
