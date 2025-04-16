using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public float moveSpeed = 5f; // Base speed of the plane
    public float verticalSpeed = 5f; // Speed of vertical movement
    public float maxY = 4f; // Maximum Y position to clamp
    public float minY = -4f; // Minimum Y position to clamp
    public float maxX = 8f; // Maximum X position to clamp (for horizontal bounds)
    public float minX = -8f; // Minimum X position to clamp
    public float speedChangeRate = 2f; // Rate at which the speed changes

    private float currentSpeed = 0f; // Current speed of the plane

    void Start()
    {
        currentSpeed = moveSpeed; // Initialize with base speed
    }

    void Update()
    {
        // Get player input for vertical movement (up/down arrow or W/S keys)
        float verticalMove = Input.GetAxis("Vertical");

        // Get player input for adjusting horizontal speed (left/right arrow or A/D keys)
        float speedAdjustment = Input.GetAxis("Horizontal") * speedChangeRate * Time.deltaTime;

        // Adjust the current speed
        currentSpeed += speedAdjustment;

        // Ensure the plane stays within screen bounds (adjust horizontal speed as needed)
        Vector3 currentPosition = transform.position;

        if (currentPosition.x > maxX && currentSpeed > 0) 
        {
            // Prevent the plane from going out of bounds on the right side
            currentSpeed = 0f;
        } 
        else if (currentPosition.x < minX && currentSpeed < 0) 
        {
            // Prevent the plane from going out of bounds on the left side
            currentSpeed = 0f;
        }

        // Move the plane vertically
        Vector3 movement = new Vector3(0, verticalMove * verticalSpeed * Time.deltaTime, 0);
        transform.Translate(movement);

        // Clamp the movement to keep the plane within the screen bounds vertically
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        transform.position = clampedPosition;

        // Move the plane forward/backward based on the current speed
        transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
    }
}
