// PlayerController.cs
// Ryan Bernal, MacEwan Game Dev Club (MGDC)
// Purpose: Show the basic use of a traditional 2D Player Controller with Basic Unity C# Codes
// Source: https://www.youtube.com/watch?v=v_VpZKK9sUQ

/* Library Delcarations */
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* Variable Declarations */
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    public float runSpeedMultiplier = 1.5f;
    public bool isRunning = false;

    /* Function Declarations Go Here */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Check to see if the script can find the Rigidbody we attached to the Player
        rb.freezeRotation = true; // Prevent Player Sprite from rotating while we move it
    }

    // Update is called once per frame
    void Update()
    {
        isRunning = Input.GetKey(KeyCode.LeftShift); // Check if Left Shift is currently being pressed

        moveInput.x = Input.GetAxisRaw("Horizontal"); // Set x to horizontal movement
        moveInput.y = Input.GetAxisRaw("Vertical"); // Set y to vertical movement
        moveInput.Normalize();
    }

    // Update is called whenever physics are changed
    void FixedUpdate()
    {
        float currentSpeed = moveSpeed; // Set the current speed of the player with the current move speed

        // If the Player is running (Left Shift is held down), multiply current speed with the run speed multiplier
        if (isRunning) 
        {
            currentSpeed *= runSpeedMultiplier;
        }

        rb.linearVelocity = moveInput * currentSpeed; // Update the linear velocity of the Rigidbody2D to reflect movement changes
    }
}