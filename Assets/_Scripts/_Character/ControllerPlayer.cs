using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    [SerializeField] GameObject Obj_Camera;
    [SerializeField] GameObject Obj_Attack;
    [SerializeField] GameObject Obj_Target;
    [SerializeField] GameObject Obj_Model;
    [SerializeField] GameObject Obj_Rotate;

    private float TECH_BaseDownMovement = 2;
    private float TECH_JumpSurfaceAngle = 45;
    private Vector3 TECH_MoveVector;
    private Vector2 TECH_MoveInputVector;
    private float TECH_MoveVertical;
    private CharacterController CharacterController;
    private RaycastHit TECH_Hit;

    private Stats Stats;

    private bool isJump;

    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
        Stats = GetComponent<Stats>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Attack();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Obj_Target.GetComponent<Activate>().ActivateTargetObject();
        }

        if (Input.GetButton("Fire2"))
        {
            Obj_Camera.GetComponent<CameraManager>().SetCameraAim(true);
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            Obj_Camera.GetComponent<CameraManager>().SetCameraAim(false);
            //RangeAttack(Arrow);
        }
        else
        {
            Obj_Camera.GetComponent<CameraManager>().SetCameraAim(false);
        }

        Movement();
    }




    void Movement()
    {
        TECH_MoveInputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        TECH_MoveInputVector = TECH_MoveInputVector.normalized * Mathf.Clamp(TECH_MoveInputVector.magnitude, 0, 1);
        TECH_MoveVector = Obj_Camera.transform.TransformVector(TECH_MoveInputVector.x, 0, TECH_MoveInputVector.y) * Stats.MoveSpeed;

        Obj_Rotate.transform.LookAt(Obj_Rotate.transform.position + TECH_MoveVector);
        if (Obj_Camera.GetComponent<CameraManager>().GetCameraAim())
        {
            Obj_Rotate.transform.rotation = Obj_Camera.transform.rotation;
        }

        //SetMoveHorizontalVector(TECH_MoveVector);

        //Gravity
        if (Physics.Raycast(transform.position, Vector3.down, 1f + TECH_SurfaceAngleToRangeCast(TECH_JumpSurfaceAngle)))
        {
            if (Input.GetButtonDown("Jump") && TECH_MoveVertical <= 0)
            {
                TECH_MoveVertical += Stats.JupmSpeed;
            }
        }
        if (Physics.SphereCast(transform.position, 0.5f, Vector3.down, out TECH_Hit, 0.6f))
        {
            if (TECH_MoveVertical < -TECH_BaseDownMovement)
            {
                TECH_MoveVertical = -TECH_BaseDownMovement;
            }
            isJump = false;
        }
        else
        {
            isJump = true;
        }


        TECH_MoveVertical -= Stats.Gravity * Time.deltaTime;
        TECH_MoveVector = new Vector3(TECH_MoveVector.x, TECH_MoveVertical, TECH_MoveVector.z);

        //End
        CharacterController.Move(TECH_MoveVector * Time.deltaTime);
    }



    // TECH ////////////


    float TECH_SurfaceAngleToRangeCast(float Angle)
    {
        return 0.5f / Mathf.Cos(Angle * Mathf.PI / 180f) - 0.5f;
    }
}
