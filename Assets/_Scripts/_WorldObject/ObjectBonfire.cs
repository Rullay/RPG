using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBonfire : WorldObject
{
    private StatsPlayer player;

    public override void Start()
    {
        base.Start();
        player = GameManager.Instance.Player.GetComponent<StatsPlayer>(); ;
    }


    public override void Activate()
    {
        base.Activate();
        player.HealthActual = player.HealthMax;
        
    }

}
