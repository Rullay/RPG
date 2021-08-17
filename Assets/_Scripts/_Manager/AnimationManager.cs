using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator AninationModelOneHandAttack;
    //public GameObject player;
    void Start()
    {
        AninationModelOneHandAttack = GetComponent<Animator>();

    }

            
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log(1);
            AninationModelOneHandAttack.Play("ModelOneHandAttack");
           // player.GetComponent<Animator>().Play("ModelOneHandAttack");
        }
    }
}
    