using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Object/Transform")]
    public static GameManager Instance = null;
    public Transform PlayerTransform;
    public GameObject Player;
    public Transform CameraBaseTransform;
    public GameObject Camera;
    public GameObject InventoryManagerObject;

    [Header("Manager")]
    public InventoryManager InventoryManager;
    public MenuManager MenuManager;
    public LevelManager LevelManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InventoryManager = InventoryManagerObject.GetComponent<InventoryManager>();
        MenuManager = transform.GetComponent<MenuManager>();
        LevelManager = transform.GetComponent<LevelManager>();
    }
}
