﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float health = 50f;

    public float moveForce = 5f;
    public float jumpForce = 1f;
    public float maxSpeed = 50f;
    public float maxHeight = 5f;

    private Rigidbody rb;
    private float moveInput;
    private bool isJumping = false;
    private float currentForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentForce = 0f;
    }

    void Update()
    {
        moveInput = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
        }

        isJumping = Input.GetKey(KeyCode.Space);

        // Update currentForce for ramp up effect
        if (moveInput != 0)
        {
            currentForce = Mathf.Min(currentForce + Time.deltaTime * moveForce, maxSpeed);
        }
        else
        {
            currentForce = 0;
        }
    }

    void FixedUpdate()
    {
        // Apply horizontal force
        rb.AddForce(new Vector3(moveInput * currentForce, 0, 0), ForceMode.Force);

        // Apply jump force
        if(transform.position.y <= maxHeight)
        {
            if (isJumping) 
            {
            Debug.Log("Jumping");
            rb.AddForce(Vector3.up, ForceMode.Impulse);
            isJumping = false;  
            }

        }


        // Since autorunner, move forward
        if(rb.velocity.z <= maxSpeed)
        {
            rb.AddForce(new Vector3(0, 0, maxSpeed), ForceMode.Force);
        }
    }

}
