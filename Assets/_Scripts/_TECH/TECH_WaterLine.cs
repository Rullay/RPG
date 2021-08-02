using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TECH_WaterLine : MonoBehaviour
{
    [SerializeField] private float ART_WaterLevel;
    private Transform TECH_PlayerTransform;

    void Start()
    {
        TECH_PlayerTransform = GameManager.Instance.PlayerTransform;
    }

    void Update()
    {
        transform.position = new Vector3(TECH_PlayerTransform.position.x, ART_WaterLevel, TECH_PlayerTransform.position.z);
    }
}
