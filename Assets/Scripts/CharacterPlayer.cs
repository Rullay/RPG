using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayer : Character
{
    //Move
    [SerializeField] private float STATS_Speed;
    [SerializeField] private float STATS_JumpSpeed;
    [SerializeField] private float STATS_Gravity;
    [SerializeField] private float STATS_BaseDownMovement;
    [SerializeField] private float STATS_JumpSurfaceAngle;
    [SerializeField] private GameObject Model;
    private Vector3 TECH_MoveVector;
    private Vector2 TECH_MoveInputVector;
    private float TECH_MoveVertical;


    //Camera
    [SerializeField] private GameObject CameraX;
    [SerializeField] private GameObject CameraY;
    [SerializeField] private Camera Camera;
    [SerializeField] private float SET_CameraMinAngle;
    [SerializeField] private float SET_CameraMaxAngle;
    [SerializeField] private float SET_CameraVerticalSens;
    [SerializeField] private float SET_CameraHorizontalSens;
    private float TECH_CameraActualAngle;


    //phisics
    private CharacterController CharacterController;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
        CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();
        CameraMovement();
    }

    void Movement()
    {
        TECH_MoveInputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        TECH_MoveInputVector = TECH_MoveInputVector.normalized * TECH_MoveInputVector.magnitude;
        TECH_MoveVector = CameraY.transform.TransformVector(TECH_MoveInputVector.x, 0, TECH_MoveInputVector.y) * STATS_Speed;
        Model.transform.LookAt(Model.transform.position + TECH_MoveVector);

        //gravity
        if (Physics.Raycast(transform.position, Vector3.down, 1f + TECH_SurfaceAngleToRangeCast(STATS_JumpSurfaceAngle)))
        {
            if (Input.GetButtonDown("Jump") && TECH_MoveVertical <= 0)
            {
                TECH_MoveVertical += STATS_JumpSpeed;
            }
        }
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 0.5f, Vector3.down, out hit, 0.6f))
        {
            if (TECH_MoveVertical < -STATS_BaseDownMovement)
            {
                TECH_MoveVertical = -STATS_BaseDownMovement;
            }
        }

        TECH_MoveVertical -= STATS_Gravity * Time.deltaTime;
        TECH_MoveVector = new Vector3(TECH_MoveVector.x, TECH_MoveVertical, TECH_MoveVector.z);

        //End
        CharacterController.Move(TECH_MoveVector * Time.deltaTime);
    }

    void CameraMovement()
    {
        //Horizontal
        CameraY.transform.Rotate(0,Input.GetAxis("Mouse X") * SET_CameraHorizontalSens,0);

        //Vertical
        TECH_CameraActualAngle = Mathf.Clamp(TECH_CameraActualAngle -= Input.GetAxis("Mouse Y") * SET_CameraVerticalSens, SET_CameraMinAngle, SET_CameraMaxAngle);
        CameraX.transform.localEulerAngles = new Vector3(TECH_CameraActualAngle,0,0);
    }

    float TECH_SurfaceAngleToRangeCast(float Angle)
    {
        return 0.5f / Mathf.Cos(Angle * Mathf.PI / 180f) - 0.5f;
    }
}
