using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float health = 50f;

    public float moveForce = 10f;
    public float jumpForce = 13f;
    public float maxSpeed = 50f;
    public float raycastDistance = 4f;

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

        Debug.DrawRay(transform.position, Vector3.down * raycastDistance, Color.red);

    }

    private bool IsGrounded()
    {
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
            rb.AddForce(new Vector3(0, 0, 1) * moveForce, ForceMode.Force);
        }
    }

}
