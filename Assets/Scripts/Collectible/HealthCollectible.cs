using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : BaseCollectible
{
    
    protected override void Collect()
    {
        base.Collect();
        //find player and add 10 health
        player.GetComponent<PlayerController>().health += 10;

    }
}   

