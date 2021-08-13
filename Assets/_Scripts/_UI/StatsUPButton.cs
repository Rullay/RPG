using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUPButton : MonoBehaviour
{
    [SerializeField] private GameObject LavelUP_Menu;
    public string NameParameter;

    public void Click()
    {             
        LavelUP_Menu.GetComponent<LevelUP_Menu>().ClickButton(NameParameter);      
    }
}
