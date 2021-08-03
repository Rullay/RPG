using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Item : MonoBehaviour
{

    [SerializeField] public Sprite item_Sprite;

    public string item_Type;

    public enum ItemTypeEnum : int
    {
        MainHand,
        OfHand,
        Head ,
        Chest,
        Artifact 
    }
    public ItemTypeEnum itemType;


    void Start()
    {
        Item_Type();
        
    }

    void Update()
    {

    }

    void Item_Type()
    {
        switch (itemType)
        {
            case ItemTypeEnum.MainHand:
                item_Type = "MainHand";
                break;

            case ItemTypeEnum.OfHand:
                item_Type = "OfHand";
                break;

            case ItemTypeEnum.Head:
                item_Type = "Head";
                break;

            case ItemTypeEnum.Chest:
                item_Type = "Chest";
                break;

            case ItemTypeEnum.Artifact:
                item_Type = "Artifact";
                break;
        }
    }

    public void Ñollected()
    {
        gameObject.SetActive(false);
    }


 }   

    

