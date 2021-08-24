using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Item : MonoBehaviour
{

    [SerializeField] public Sprite item_Sprite;
    public string item_Type;
    public string animation_Type;

    private enum ItemType
    {
        MainHand,
        OfHand,
        Head,
        Chest,
        Artifact
    }
    [SerializeField] private ItemType itemType;

    private enum AnimationType
    {
        OneHand,
        TwoHand, 
        Bow,
        Staff,
        Shield
    }
    [SerializeField] private AnimationType animationType;


    public void Start()
    {
        WriteType();
        WriteAnimationType();
    }

    public void WriteType()
    {
        switch (itemType)
        {
            case ItemType.MainHand:
                item_Type = "MainHand";
                break;
            case ItemType.OfHand:
                item_Type = "OfHand";
                break;
            case ItemType.Head:
                item_Type = "Head";
                break;
            case ItemType.Chest:
                item_Type = "Chest";
                break;
            case ItemType.Artifact:
                item_Type = "Artifact";
                break;

        }
    }

    public void WriteAnimationType()
    {
        switch (animationType)
        {
            case AnimationType.OneHand:
                animation_Type = "OneHand";
                break;
            case AnimationType.TwoHand:
                animation_Type = "TwoHand";
                break;
            case AnimationType.Bow:
                animation_Type = "Bow";
                break;
            case AnimationType.Staff:
                animation_Type = "Staff";
                break;
            case AnimationType.Shield:
                animation_Type = "Shield";
                break;

        }

    }

    public void Collected()
    {
        gameObject.SetActive(false);
    }
}





