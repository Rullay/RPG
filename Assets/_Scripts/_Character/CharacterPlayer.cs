using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CharacterPlayer : Character
{
    protected override void Start()
    {
        base.Start();
        //DontDestroyOnLoad(gameObject);
        CameraTransform = GameManager.Instance.CameraBaseTransform;
        InitializedActivate();
        InitializedPlayerMovement();
        SaveStats();
    }

    void Update()
    {
        UpdateObjectInTarget();
        PlayerControl();
        Movement();
        animator.SetFloat("Speed", TECH_MoveInputVector.magnitude);
    }

    void PlayerControl()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivateTargetObject();
        }

        if (Input.GetButton("Fire2"))
        {
            CameraTransform.GetComponent<CameraManager>().SetCameraAim(true);
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            CameraTransform.GetComponent<CameraManager>().SetCameraAim(false);
            RangeAttack(Arrow);
        }
        else
        {
            CameraTransform.GetComponent<CameraManager>().SetCameraAim(false);
        }
    }
}
