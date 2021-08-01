using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float SET_DayTimeScale;
    [SerializeField] private float SET_DayTimeStart;

    [SerializeField] private float SET_LightAngle;
    [SerializeField] private GameObject DirectionLight;
    private float TECH_ActualTime;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        TECH_ActualTime = SET_DayTimeStart;
    }

    void Update()
    {
        TECH_ActualTime += Time.deltaTime * SET_DayTimeScale * 0.0000116f;
        if (TECH_ActualTime > 1) { TECH_ActualTime -= 1;}
        DirectionLight.transform.localEulerAngles = new Vector3(TECH_ActualTime * 360 - 90, SET_LightAngle, 0);
    }
}
