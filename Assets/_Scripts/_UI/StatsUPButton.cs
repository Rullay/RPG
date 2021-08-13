using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUPButton : MonoBehaviour
{
    public bool TECH_Click;
    [SerializeField] private GameObject LavelUP_Menu;
    public string NameParameter;

    public void Click()
    {
        
        TECH_Click = true;
        LavelUP_Menu.GetComponent<LevelUP_Menu>().ClickButton();
        TECH_Click = false;
    }
}
