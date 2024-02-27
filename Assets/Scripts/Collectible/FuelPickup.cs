using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickup : BaseCollectible
{
    public GameObject Collecting;
    protected override void Collect()
    {
        base.Collect();
        //find player and add 10 fuel
        player.GetComponent<PlayerController>().fuel += 30;

        if(Collecting != null)
        {
            Instantiate(Collecting, transform.position, Quaternion.identity);
        }
    }
}
