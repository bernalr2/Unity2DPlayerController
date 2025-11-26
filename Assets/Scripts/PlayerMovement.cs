// PlayerMovement.cs
// Ryan Bernal, MacEwan Game Dev Club (MGDC)
// Purpose: Show the basic implementation of a Player Movement Controller with the new input system
// Source: https://www.youtube.com/watch?v=24-BkpFSZuI

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    /* Variable Declarations */
    private Rigidbody2D rb;
    private float horizontal; 
    private float vertical;
    private float moveSpeed = 5f;

    private float runSpeedMultiplier = 1.5f;
    private bool isRunning = false;

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
        float currentSpeed = moveSpeed; // Set the current speed of the player with the current move speed

        isRunning = Input.GetKey(KeyCode.LeftShift); // Check if Left Shift is currently being pressed

        // If the Player is running (Left Shift is held down), multiply current speed with the run speed multiplier
        if (isRunning) 
        {
            currentSpeed *= runSpeedMultiplier;
        }

        rb.linearVelocity = new Vector2(horizontal * currentSpeed, vertical * currentSpeed);
    }

    // Use the InputSystem to update horizontal and vertical contexts of the Player
    public void Move(InputAction.CallbackContext context) 
    {
        horizontal = context.ReadValue<Vector2>().x; // Update horizontal value
        vertical = context.ReadValue<Vector2>().y; // Update vertical value
    }
}