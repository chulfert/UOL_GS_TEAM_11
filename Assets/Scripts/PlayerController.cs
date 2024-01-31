using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 5f;
    public float jumpForce = 13f;
    public float maxSpeed = 10f;

    private Rigidbody rb;
    private float moveInput;
    private bool isJumping;
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

        isJumping = Input.GetKeyDown(KeyCode.Space);

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
        if (isJumping ) // 
        {
            Debug.Log("Jumping");
            rb.AddForce(Vector3.up * 30, ForceMode.Impulse);
        }

        // Since autorunner, move forward
        if(rb.velocity.z < maxSpeed)
        {
            rb.AddForce(new Vector3(0, 0, 10.0f), ForceMode.Force);
        }
    }
}
