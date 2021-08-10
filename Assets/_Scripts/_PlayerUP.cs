using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerUP : MonoBehaviour
{
    // ссылка на character

    [SerializeField] private int experiencePlayer;
    [SerializeField]  private int lavel = 1;
    [SerializeField] private int neededExperince;

    

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            experiencePlayer += 100;
        }
        LavelUP();
    }

    void LavelUP()
    {
        if (lavel == 1)
        {
            neededExperince = 100;
        }

        if (experiencePlayer >= neededExperince)
        {         
            experiencePlayer = experiencePlayer - neededExperince;         
            lavel += 1;
            neededExperince = neededExperince + neededExperince/(10 + lavel) + lavel * 10 /*lavel/(10 + lavel)*/;
        }

    }

        
}
