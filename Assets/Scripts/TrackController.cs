using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackController : MonoBehaviour
{

    float maxForce = 10f;
    Collider playerCollider;
    float minDistance = 6f;
    float maxDistance = 10f;

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
            playerCollider = other;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && playerCollider != null)
        {
            ApplyMagneticForce(playerCollider.gameObject);
        }
    }

    void ApplyMagneticForce(GameObject player)
    {
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        Vector3 forceDirection = (transform.position - player.transform.position).normalized;
        forceDirection.z = 0;
        float forceMagnitude = CalculateForceMagnitude(player.transform.position);
        Vector3 forceTotal = forceDirection * forceMagnitude * 5;

        //limit to y axis
        forceTotal.x = 0;
        forceTotal.z = 0;      
        playerRb.AddForce(forceTotal, ForceMode.Acceleration);
    }


    float CalculateForceMagnitude(Vector3 playerPosition)
    {
        float distance = Mathf.Abs(transform.position.y - playerPosition.y);
        float normalizedDistance = (distance - minDistance) / (maxDistance - minDistance);

        if (distance < minDistance)
        {
            // Inside the minimum distance, apply a strong repulsive force
            float repelForce = maxForce * Mathf.Pow((minDistance - distance) / minDistance, 2);
            return -Mathf.Clamp(repelForce, 0, maxForce);
        }
        else if (distance >= minDistance && distance <= maxDistance)
        {
            // Between min and max distance, apply an attractive force that increases sharply as the object approaches the track
            float attractForce = maxForce * normalizedDistance * 0.1f;
            return Mathf.Clamp(attractForce, 0, maxForce);
        }
        else
        {
            // Beyond max distance, no force is applied
            return 0;
        }
    }
}
