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
            if (StatsButton[i].GetComponent<StatsUPButton>().TECH_Click == true)
            {               
                 GameManager.Instance.Player.GetComponent<CharacterPlayer>().UpStats(StatsButton[i].GetComponent<StatsUPButton>().NameParameter);               
            }
        }
    }
}
