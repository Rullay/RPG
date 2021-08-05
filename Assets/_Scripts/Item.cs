using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Item : MonoBehaviour
{

    [SerializeField] public Sprite item_Sprite;
    public string item_Type;

    


    void Start()
    {
       
        
    }

    void Update()
    {

    }

    
    public void Collected()
    {
        gameObject.SetActive(false);
    }


 }   

    

