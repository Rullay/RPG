using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator Animator;
    [SerializeField] GameObject Model;

    void Start()
    {
        Animator = Model.GetComponent<Animator>();
    }

    public void SetMoveHorizontal(float Speed)
    {
        Animator.SetFloat("Speed", Speed);
    }

    public void PlayAttackAnimation(string WeaponeType)
    {
        switch (WeaponeType)
        {
            case "OneHand":
                Animator.SetTrigger("OneHandAttack");
                break;
            //case "TwoHand":
            //    Animator.SetTrigger("TwoHandAttack");
            //    break;
            //case "Staff":
            //    Animator.SetTrigger("StaffAttack");
            //    break;
        }
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
