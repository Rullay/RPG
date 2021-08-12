using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private GameObject Camera;

    private Transform CameraPointWatch;

    [SerializeField] private Transform CameraX;
    [SerializeField] private Transform CameraOffset;

    [SerializeField] private float SET_CameraMinAngle;
    [SerializeField] private float SET_CameraMaxAngle;
    [SerializeField] private float SET_CameraVerticalSens;
    [SerializeField] private float SET_CameraHorizontalSens;

    [SerializeField] private float SET_CameraRange;
    [SerializeField] private float SET_CameraRangeAim;
    [SerializeField] private float SET_CameraSpeed;
    [SerializeField] private float SET_CameraOffset;
    [SerializeField] private float SET_CameraTimeToBack;


    private float TECH_CameraRangeActual;
    private float TECH_CameraOffsetActual;
    private float TECH_CameraTimeToBackActual;

    private bool TECH_isCameraAim;
    private bool TECH_isCameraWatchToPoint;
    private float TECH_CameraActualAngle;

    private Transform PlayerTransform;
    private RaycastHit TECH_Hit;


    void Start()
    {
        Initialized();
    }

    void LateUpdate()
    {
        transform.position = PlayerTransform.position;
        if (!TECH_isCameraWatchToPoint)
        {
            //Range + Offset
            if (TECH_CameraTimeToBackActual > 0 && !TECH_isCameraAim)
            {
                TECH_CameraTimeToBackActual -= Time.deltaTime;
            }
            else
            {
                if (!TECH_isCameraAim)
                {
                    TECH_CameraRangeActual += SET_CameraSpeed * Time.deltaTime;
                    TECH_CameraOffsetActual -= SET_CameraSpeed * SET_CameraOffset / (SET_CameraRange - SET_CameraRangeAim) * Time.deltaTime;
                }
                else
                {
                    TECH_CameraRangeActual -= SET_CameraSpeed * Time.deltaTime;
                    TECH_CameraOffsetActual += SET_CameraSpeed * SET_CameraOffset / (SET_CameraRange - SET_CameraRangeAim) * Time.deltaTime;
                    if (TECH_CameraRangeActual <= SET_CameraRangeAim)
                    {
                        TECH_CameraTimeToBackActual = SET_CameraTimeToBack;
                    }
                }
                TECH_CameraRangeActual = Mathf.Clamp(TECH_CameraRangeActual, SET_CameraRangeAim, SET_CameraRange);
                TECH_CameraOffsetActual = Mathf.Clamp(TECH_CameraOffsetActual, 0, SET_CameraOffset);

                CameraOffset.localPosition = new Vector3(TECH_CameraOffsetActual, 0, 0);
            }


            //Raycast
            if (Physics.Raycast(CameraOffset.position, Camera.transform.position - CameraOffset.transform.position, out TECH_Hit, TECH_CameraRangeActual))
            {
                Camera.transform.position = CameraOffset.position + (TECH_Hit.point - CameraOffset.position) * 0.9f;
            }
            else
            {
                Camera.transform.localPosition = new Vector3(0, 0, -TECH_CameraRangeActual);
            }

            //Horizontal
            transform.Rotate(0, Input.GetAxis("Mouse X") * SET_CameraHorizontalSens, 0);

            //Vertical
            TECH_CameraActualAngle = Mathf.Clamp(TECH_CameraActualAngle -= Input.GetAxis("Mouse Y") * SET_CameraVerticalSens, SET_CameraMinAngle, SET_CameraMaxAngle);
            CameraX.localEulerAngles = new Vector3(TECH_CameraActualAngle, 0, 0);
        }
        else
        {
            Camera.transform.position = CameraPointWatch.position;
            Camera.transform.rotation = CameraPointWatch.rotation;
        }
    }

    void Initialized()
    {
        PlayerTransform = GameManager.Instance.PlayerTransform;
        Camera = GameManager.Instance.Camera;
        TECH_CameraRangeActual = SET_CameraRange;
        TECH_CameraOffsetActual = 0;
    }

    public void SetCameraAim(bool State)
    {
        TECH_isCameraAim = State;
    }

    public bool GetCameraAim()
    {
        return (TECH_isCameraAim || TECH_CameraTimeToBackActual > 0);
    }
}
