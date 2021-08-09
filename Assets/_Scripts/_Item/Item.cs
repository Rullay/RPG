using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Item : MonoBehaviour
{

    [SerializeField] public Sprite item_Sprite;
    public string item_Type;

    public enum ItemType
    {
        MainHand,
        OfHand,
        Head,
        Chest,
        Artifact
    }
    public ItemType itemType;


    public void Start()
    {
        WriteType();
    }

    void Update()
    {
        
    }

    public void WriteType()
    {
        switch(itemType)
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


    public void Collected()
    {
        gameObject.SetActive(false);
    }


 }   

    

