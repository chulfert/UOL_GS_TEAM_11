﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollectible : MonoBehaviour
{
    protected bool isAttracted = false;
    protected GameObject player;

    public virtual void StartAttracting(GameObject playerObject)
    {
        isAttracted = true;
        player = playerObject;
    }

    protected virtual void Update()
    {
        if (isAttracted)
        {
            // Move towards the player
            float step = 5f * Time.deltaTime; // Adjust speed as needed
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        // Collect the item or disable it
        gameObject.SetActive(false);
    }
}
