using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayer : Character
{
    //Move
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float MoveGravity;
    [SerializeField] private float MoveBaseGravity;
    [SerializeField] private float JumpSpeed;
    [SerializeField] private GameObject Model;
    private Vector3 MoveVector;
    private Vector2 MoveInputVector;
    private float MoveVertical;


    //Camera
    [SerializeField] private GameObject CameraX;
    [SerializeField] private GameObject CameraY;
    [SerializeField] private Camera Camera;
    [SerializeField] private float CameraMinAngle;
    [SerializeField] private float CameraMaxAngle;
    [SerializeField] private float CameraVerticalSens;
    [SerializeField] private float CameraHorizontalSens;
    private float CameraActualAngle;


    //phisics
    private Rigidbody Rigidbody;


    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
        CameraMovement();
    }

    void Movement()
    {
        MoveInputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        MoveInputVector = MoveInputVector.normalized * MoveInputVector.magnitude;
        MoveVector = CameraY.transform.TransformVector(MoveInputVector.x, 0, MoveInputVector.y) * MoveSpeed;
        Model.transform.LookAt(Model.transform.position + MoveVector);

        //gravity
        RaycastHit hit;
        if (Physics.Raycast(Model.transform.position, Vector3.down, 1.1f))
        {
            if (MoveVertical < 0)
            {
                MoveVertical = 0;
            }
            if (Input.GetButtonDown("Jump"))
            {
                MoveVertical += JumpSpeed;
            }
        }
        else
        {
            MoveVertical -= MoveGravity * Time.deltaTime;
            if (Physics.SphereCast(Model.transform.position, 0.5f, Vector3.down, out hit, 0.6f))
            {
                if (MoveVertical < MoveBaseGravity)
                {
                    MoveVertical = MoveBaseGravity;
                }
            }
        }

        MoveVector = new Vector3(MoveVector.x, MoveVertical, MoveVector.z);

        //End
        Rigidbody.velocity = MoveVector;
    }

    void CameraMovement()
    {
        //Horizontal
        CameraY.transform.Rotate(0,Input.GetAxis("Mouse X") * CameraHorizontalSens,0);

        //Vertical
        CameraActualAngle = Mathf.Clamp(CameraActualAngle -= Input.GetAxis("Mouse Y") * CameraVerticalSens, CameraMinAngle, CameraMaxAngle);
        CameraX.transform.localEulerAngles = new Vector3(CameraActualAngle,0,0);

    }
}
