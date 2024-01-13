using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackController : MonoBehaviour
{

    [SerializeField]
    public float maxForce = 5f;
    [SerializeField]
    float maxDistance = 20f;
    [SerializeField]
    Collider player_collider;
    [SerializeField]
    float minDistance = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player_collider = other;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyMagneticForce(player_collider.gameObject);
        }
    }

    void ApplyMagneticForce(GameObject player)
    {
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        Vector3 forceDirection = (transform.position - player.transform.position).normalized;
        forceDirection.z = 0;
        float forceMagnitude = CalculateForceMagnitude(player.transform.position);
        Vector3 forceTotal = forceDirection * forceMagnitude;
      
        playerRb.AddForce(forceTotal, ForceMode.Acceleration);
    }


    float CalculateForceMagnitude(Vector3 playerPosition)
    {
        Vector3 trackPosition2D = new Vector3(transform.position.x, transform.position.y, 0);
        Vector3 playerPosition2D = new Vector3(playerPosition.x, playerPosition.y, 0);

        float distance = Vector3.Distance(trackPosition2D, playerPosition2D);
        
        
        if (distance < minDistance)
        {
            // Inside the minimum distance, reverse the force
            return -Mathf.Clamp(maxForce * (Mathf.Pow(2, minDistance - distance)), 0, maxForce) ;
        }
        else
        {
            // Outside the minimum distance, normal attractive force
            return Mathf.Clamp(maxForce * (1 - Mathf.Pow(distance / maxDistance, 2)  ), 0, maxForce) ;
        }
    }
}
