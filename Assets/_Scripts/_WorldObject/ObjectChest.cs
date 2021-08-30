using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChest : WorldObject
{
    [SerializeField] private GameObject ItemPrefab;
    private bool TECH_isOpen = false;
    private GameObject TECH_ItemObject;

    public override void Start()
    {
        base.Start();
        TECH_ItemObject = GameObject.Instantiate(ItemPrefab);
        //TECH_ItemObject.SetActive(false);
    }

    public override void Activate()
    {
        base.Activate();
        if (!TECH_isOpen)
        {
            TECH_ItemObject.transform.parent = GameManager.Instance.PlayerTransform;
            GameManager.Instance.InventoryManager.ItemDispenser(TECH_ItemObject);
            TECH_isOpen = true;
        }
    }
}
