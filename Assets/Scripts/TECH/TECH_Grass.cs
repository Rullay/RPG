using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TECH_Grass : MonoBehaviour
{
    [SerializeField] private List<GameObject> GrassPartList;
    [SerializeField] private float ART_MinScaleGrass;
    [SerializeField] private float ART_MaxScaleGrass;
    [SerializeField] private float ART_MinHighGrass;
    [SerializeField] private float ART_MaxHighGrass;

    void Start()
    {
        SetScaleGrass();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetScaleGrass()
    {
        float TECH_GrassLocalScale;
        float TECH_GrassLocalHigh;
        for (int i=0; i<GrassPartList.Count; i++)
        {
            TECH_GrassLocalScale = Random.Range(ART_MinScaleGrass, ART_MaxScaleGrass);
            TECH_GrassLocalHigh = Random.Range(ART_MinHighGrass, ART_MaxHighGrass);

            GrassPartList[i].transform.localScale = new Vector3(TECH_GrassLocalScale, TECH_GrassLocalHigh, TECH_GrassLocalScale);
        }
    }
}
