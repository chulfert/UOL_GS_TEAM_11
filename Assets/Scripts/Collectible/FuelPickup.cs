using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickup : BaseCollectible
{
    public GameObject Collecting;

    protected override void Collect()
    {
        base.Collect();
        // Find player and add fuel, ensuring it does not exceed 100
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.fuel = Mathf.Min(playerController.fuel + 30, 100);

        if (Collecting != null)
        {
            Instantiate(Collecting, transform.position, Quaternion.identity);
        }
    }
}
