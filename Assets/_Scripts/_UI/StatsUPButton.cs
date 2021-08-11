using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUPButton : MonoBehaviour
{
    public bool clik;
    [SerializeField] private GameObject LavelUP_Menu;
    public string NameParameter;

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void Clik()
    {
        
        clik = true;
        LavelUP_Menu.GetComponent<_LavelUP_Menu>().ClickButton();
        clik = false;
    }
}
