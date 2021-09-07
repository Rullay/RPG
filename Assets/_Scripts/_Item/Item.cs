using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Item : MonoBehaviour
{
    [SerializeField] public Sprite item_Sprite;
    private string TECH_ItemType;
    public int id;

    private enum ItemType
    {
        MainHand,
        OfHand,
        Head,
        Chest,
        Artifact
    }
    [SerializeField] private ItemType itemType;

    public virtual void Start()
    {
        WriteType();
    }

    void WriteType()
    {
        switch (itemType)
        {
            case ItemType.MainHand:
                TECH_ItemType = "MainHand";
                break;
            case ItemType.OfHand:
                TECH_ItemType = "OfHand";
                break;
            case ItemType.Head:
                TECH_ItemType = "Head";
                break;
            case ItemType.Chest:
                TECH_ItemType = "Chest";
                break;
            case ItemType.Artifact:
                TECH_ItemType = "Artifact";
                break;

        }
    }

    public string GetItemType()
    {
        return TECH_ItemType;
    }
}





