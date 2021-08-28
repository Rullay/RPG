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

    public void PlayAttackAnimation(float AttackSpeed, string WeaponeType)
    {

        Animator.SetFloat("SpeedAnimation", 1 / AttackSpeed);

        switch (WeaponeType)
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
        StartCoroutine(StopAttackAnimation(AttackSpeed));
    }

    IEnumerator StopAttackAnimation(float AnimationTime)
    {
        yield return new WaitForSeconds(AnimationTime);
        Animator.SetBool("OneHandAttack", false);
        Animator.SetBool("TwoHandAttack", false);
        Animator.SetBool("BowAttack", false);
        Animator.SetBool("StaffAttack", false);
        GameManager.Instance.Player.GetComponent<ControllerPlayer>().AttackEnd();
    }

    public void AnimationPlayAim(string WeaponeType)
    {
        switch (WeaponeType)
        {
            case "Bow":
                Animator.SetBool("BowAim", true);
                break;
            case "Staff":
                Animator.SetBool("StaffAim", true);
                break;
        }
    }
    public void AnimationStopAim()
    {
        Animator.SetBool("BowAim", false);
        // Animator.SetBool("StaffAim", false);
    }

}
