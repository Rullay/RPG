using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUP_Menu : MonoBehaviour
{
    [SerializeField] private List<GameObject> StatsButton;


    public void ClickButton(string NameParameter)
    {
        GameManager.Instance.Player.GetComponent<StatsPlayer>().UpStats(NameParameter);
    }
}
