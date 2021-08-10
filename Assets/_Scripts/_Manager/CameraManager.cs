using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] private GameObject CameraX;
    [SerializeField] private Camera Camera;
    [SerializeField] private float SET_CameraMinAngle;
    [SerializeField] private float SET_CameraMaxAngle;
    [SerializeField] private float SET_CameraVerticalSens;
    [SerializeField] private float SET_CameraHorizontalSens;
    private float TECH_CameraActualAngle;

    private Transform PlayerTransform;

    void Start()
    {
        PlayerTransform = GameManager.Instance.PlayerTransform;
    }

    void LateUpdate()
    {
        transform.position = PlayerTransform.position;

        //Horizontal
        transform.Rotate(0, Input.GetAxis("Mouse X") * SET_CameraHorizontalSens, 0);

        //Vertical
        TECH_CameraActualAngle = Mathf.Clamp(TECH_CameraActualAngle -= Input.GetAxis("Mouse Y") * SET_CameraVerticalSens, SET_CameraMinAngle, SET_CameraMaxAngle);
        CameraX.transform.localEulerAngles = new Vector3(TECH_CameraActualAngle, 0, 0);
    }
}
