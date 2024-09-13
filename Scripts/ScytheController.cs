using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheController : MonoBehaviour
{
    public GameObject player;
    public float swingSpeed = 200f; // Speed of swinging
    private float currentAngle = 0f; // Current swing angle
    private bool isSwinging = false; // Track if the scythe is swinging
    private float swingDirection = 1f; // Swing direction (1 for right, -1 for left)

    private void Start()
    {
        //this.transform.Rotate(0, 0, 9   0);
    }


    // Update is called once per frame
    void Update()
    {
        // Follow the player's position
        this.transform.position = player.transform.position;

        // Check for left mouse button click to start swinging
        if (Input.GetMouseButtonDown(0) && !isSwinging)
        {
            isSwinging = true; // Start the swing
            swingDirection = 1f; // Initialize swing to the right
            currentAngle = -90f; // Start swing angle at -90 degrees
        }

        // Handle swinging
        if (isSwinging)
        {
            SwingScythe();
        }
    }

    void SwingScythe()
    {
        // Calculate swing angle increment
        float angleIncrement = swingSpeed * Time.deltaTime * swingDirection;

        // Update the current swing angle
        currentAngle += angleIncrement;

        // Rotate the scythe around the player's position
        this.transform.position = player.transform.position + Quaternion.Euler(0, 0, currentAngle) * Vector3.right;

        // Reverse direction if angle exceeds bounds
        if (currentAngle >= 90f)
        {
            swingDirection = -1f; // Swing back to the left
        }
        else if (currentAngle <= -90f)
        {
            // End swinging when the arc completes
            isSwinging = false; // Stop the swing
        }
    }
}
