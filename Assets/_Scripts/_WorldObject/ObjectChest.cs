using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChest : WorldObject
{
    [SerializeField] private GameObject ItemPrefab;
    private bool TECH_isOpen = false;

    public override void Start()
    {
        base.Start();
    }

    public override void Activate()
    {
        base.Activate();
        if (!TECH_isOpen)
        {
            GameManager.Instance.InventoryManager.ItemDispenser(ItemPrefab);
            TECH_isOpen = true;
        }
    }
}
