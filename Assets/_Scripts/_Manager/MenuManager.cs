using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject InventaryMenu;
    [SerializeField] private GameObject LevelUpMenu;
    [SerializeField] private GameObject LeftBoxMenu;

    private bool TECH_IsMenuEnable;

    void Start()
    {
        InitializedMenu();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            TECH_IsMenuEnable = !TECH_IsMenuEnable;
            InventaryMenu.SetActive(TECH_IsMenuEnable);
            LevelUpMenu.SetActive(TECH_IsMenuEnable);
        }
    }

    void InitializedMenu()
    {
        InventaryMenu.SetActive(false);
        LevelUpMenu.SetActive(false);
        TECH_IsMenuEnable = false;
        SetScaleMenu();
    }

    void SetScaleMenu()
    {
        float ScreenRatio = (float)(Screen.height) / (float)(Screen.width);
        LeftBoxMenu.GetComponent<RectTransform>().anchorMax = new Vector2(ScreenRatio,1f);
    }

    public bool isMenuEnabled()
    {
        return TECH_IsMenuEnable;
    }
}
