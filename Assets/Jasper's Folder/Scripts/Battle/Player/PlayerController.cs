using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // References
    PlayerStats stats; // Reference to the PlayerStats component
    Rigidbody2D rb; // Reference to the Rigidbody2D component
    Vector2 movement; // Variable to store movement input

    // Variables
    public float moveSpeed;
    float moveSpeedReal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get references
        stats = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.active)
        {
            // Get input
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            // Slowdown
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            {
                moveSpeedReal = moveSpeed / 2;
            }
            else
            {
                moveSpeedReal = moveSpeed;
            }
        }
    }

    void FixedUpdate()
    {
        // Execute movement
        rb.linearVelocity = movement * moveSpeedReal;
    }
}
