using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    protected virtual void Start()
    {
        InitializedAttack();
        InitializedStats();
        InitializedModel();
        
    }
    protected virtual void Update()
    {
        UpdateAnimation();
    }


}
