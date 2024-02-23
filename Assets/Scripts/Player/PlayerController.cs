﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float health = 50f;
    public float fuel = 100f;

    public float moveForce = 10f;
    public float jumpForce = 13f;
    public float maxSpeed = 100f;
    public float raycastDistance = 4f;

    private Rigidbody rb;
    private float moveInput;
    private bool isJumping = false;
    private float currentForce;

    void Start()
    {
        Time.timeScale = 1;
        //Get the timer and start it
       
        GameObject timer = GameObject.Find("Timer");
        Component timerComponent = timer.GetComponent<Timer>();    
        if(timerComponent == null)
        {
            Debug.LogError("Timer not found on player");
        }
        else
            ((Timer)timerComponent).StartTimer();
        rb = GetComponent<Rigidbody>();
        if(rb == null)
        {
            Debug.LogError("Rigidbody not found on player");
        }
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

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            isJumping = true;
        }


        // Update currentForce for ramp up effect
        if (moveInput != 0)
        {
            currentForce = Mathf.Min(currentForce + Time.deltaTime * moveForce, maxSpeed);
        }
        else
        {
            currentForce = 0;
        }

        fuel -= Time.deltaTime;
        //Debug.DrawRay(transform.position, Vector3.down * raycastDistance, Color.red);

        if (fuel <= 0 || health <= 0 ||transform.position.y < 0)
        {
            // Call the TriggerGameOver method from the GameOverController
            FindObjectOfType<GameOverController>().TriggerGameOver();
            GameObject.Find("Timer").GetComponent<Timer>().StopTimer();
        }

        // Find the camera, the attached canvas, the attached text 'HealthDisplay' and set the text to the health value
        GameObject.Find("Main Camera").transform.Find("Canvas").transform.Find("HealthDisplay").GetComponent<UnityEngine.UI.Text>().text = "Health: " + health; 
        GameObject.Find("Main Camera").transform.Find("Canvas").transform.Find("FuelDisplay").GetComponent<UnityEngine.UI.Text>().text = "Fuel: " + fuel;

    }

    private bool IsGrounded()
    {
        // Watch out, casting every frame, works only if not rotated.
        return Physics.Raycast(transform.position, Vector3.down, raycastDistance);

    }

    void FixedUpdate()
    {
        // Apply horizontal force
        rb.AddForce(new Vector3(moveInput * currentForce, 0, 0), ForceMode.Force);

        // Apply jump force
        if (IsGrounded() && isJumping) 
        {
        Debug.Log("Jumping");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJumping = false;  
        }

        // Since autorunner, move forward
        if(rb.velocity.z <= maxSpeed)
        {
            rb.AddForce(new Vector3(0, 0, 20), ForceMode.Force);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Player died");
        }
    }

}
