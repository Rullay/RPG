using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject InventaryMenu;
    [SerializeField] private GameObject LevelUpMenu;

    private bool TECH_IsMenuEnable;

    void Start()
    {
        InitializedMenu();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
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
    }
}
