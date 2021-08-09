using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayer : Character
{
    [SerializeField] private GameObject Model;
    private float TECH_BaseDownMovement = 2;
    private float TECH_JumpSurfaceAngle = 45;
    private Vector3 TECH_MoveVector;
    private Vector2 TECH_MoveInputVector;
    private float TECH_MoveVertical;

    private Transform CameraTransform;

    //phisics
    private CharacterController CharacterController;


    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        CharacterController = GetComponent<CharacterController>();
        CameraTransform = GameManager.Instance.CameraBaseTransform;
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        TECH_MoveInputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        TECH_MoveInputVector = TECH_MoveInputVector.normalized * TECH_MoveInputVector.magnitude;
        TECH_MoveVector = CameraTransform.TransformVector(TECH_MoveInputVector.x, 0, TECH_MoveInputVector.y) * STATS_MoveSpeed;
        Model.transform.LookAt(Model.transform.position + TECH_MoveVector);

        //gravity
        if (Physics.Raycast(transform.position, Vector3.down, 1f + TECH_SurfaceAngleToRangeCast(TECH_JumpSurfaceAngle)))
        {
            if (Input.GetButtonDown("Jump") && TECH_MoveVertical <= 0)
            {
                TECH_MoveVertical += STATS_JupmSpeed;
            }
        }
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 0.5f, Vector3.down, out hit, 0.6f))
        {
            if (TECH_MoveVertical < -TECH_BaseDownMovement)
            {
                TECH_MoveVertical = -TECH_BaseDownMovement;
            }
        }

        TECH_MoveVertical -= STATS_Gravity * Time.deltaTime;
        TECH_MoveVector = new Vector3(TECH_MoveVector.x, TECH_MoveVertical, TECH_MoveVector.z);

        //End
        CharacterController.Move(TECH_MoveVector * Time.deltaTime);
    }

    float TECH_SurfaceAngleToRangeCast(float Angle)
    {
        return 0.5f / Mathf.Cos(Angle * Mathf.PI / 180f) - 0.5f;
    }
}
