using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform CameraX;
    [SerializeField] private Transform Camera;

    [SerializeField] private float SET_CameraMinAngle;
    [SerializeField] private float SET_CameraMaxAngle;
    [SerializeField] private float SET_CameraVerticalSens;
    [SerializeField] private float SET_CameraHorizontalSens;

    [SerializeField] private float SET_CameraRange;
    [SerializeField] private float SET_CameraRangeAim;
    [SerializeField] private float SET_CameraSpeed;
    [SerializeField] private float SET_CameraOffset;

    private float TECH_CameraRangeActual;
 
    private bool TECH_isCameraAim;
    private bool TECH_isCameraWatchToPoint;
    private float TECH_CameraActualAngle;

    private RaycastHit TECH_Hit;

    void Start()
    {
        TECH_CameraRangeActual = SET_CameraRange;
        //TECH_MenuManager = GameManager.Instance.transform.GetComponent<MenuManager>();
    }

    void LateUpdate()
    {
        //Range


            if (!TECH_isCameraAim)
            {
                TECH_CameraRangeActual += SET_CameraSpeed * Time.deltaTime;
            }
            else
            {
                TECH_CameraRangeActual -= SET_CameraSpeed * Time.deltaTime;
                
            }
            TECH_CameraRangeActual = Mathf.Clamp(TECH_CameraRangeActual, SET_CameraRangeAim, SET_CameraRange);
        


        //Raycast
        if (Physics.Raycast(transform.position, Camera.transform.position - transform.position, out TECH_Hit, TECH_CameraRangeActual))
        {
           
            Camera.transform.position = transform.position + (TECH_Hit.point - transform.position) * 0.9f;
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

    public void SetCameraAim(bool State)
    {
        TECH_isCameraAim = State;
    }

    public bool GetCameraAim()
    {
        return (TECH_isCameraAim);
    }
}
