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
    }

    public override void Activate()
    {
        base.Activate();
        if (!TECH_isOpen)
        {
            TECH_ItemObject = GameObject.Instantiate(ItemPrefab, GameManager.Instance.PlayerTransform);
            TECH_ItemObject.SetActive(false);

            GameManager.Instance.InventoryManager.ItemDispenser(TECH_ItemObject);
            TECH_isOpen = true;
        }
    }
}
