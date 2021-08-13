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
    }

    void PlayerControl()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            ActivateTargetObject();
        }

        if (Input.GetKey(KeyCode.O))
        {
            CameraTransform.GetComponent<CameraManager>().SetCameraAim(true);
        }
        else if (Input.GetKeyUp(KeyCode.O))
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
