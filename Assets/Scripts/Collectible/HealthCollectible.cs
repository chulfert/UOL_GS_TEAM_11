using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : BaseCollectible
{

    public GameObject Collecting;
    
    protected override void Collect()
    {
        base.Collect();
        //find player and add 10 health
        PlayerController playerController = player.GetComponent<PlayerController>();

        if(player.GetComponent<PlayerController>().health < 50)
        {
            player.GetComponent<PlayerController>().health += 10;

            // Update the health bar
            playerController.healthBar.SetHP(playerController.health);
        }

        if(Collecting != null)
        {
            Instantiate(Collecting, transform.position, Quaternion.identity);
        }
    }
}   

