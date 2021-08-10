using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _LavelUP_Menu : MonoBehaviour
{
    [SerializeField] private List<GameObject> StatsButton;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

   public void ClickButton()
   {
        for(int i = 0; i < StatsButton.Count; i++)
        {
            if(StatsButton[i].GetComponent<StatsUPButton>().clik == true)
            {              
                Debug.Log(StatsButton[i].transform.gameObject.name);
            }
        }       
   }
}
