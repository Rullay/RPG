using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUP_Menu : MonoBehaviour
{
    [SerializeField] private List<GameObject> StatsButton;

    public void ClickButton()
    {
        for (int i = 0; i < StatsButton.Count; i++)
        {
            if (StatsButton[i].GetComponent<StatsUPButton>().clik == true)
            {               
                 GameManager.Instance.Player.GetComponent<CharacterPlayerController>().GetStatPoint(StatsButton[i].GetComponent<StatsUPButton>().NameParameter);               
            }
        }
    }
}
