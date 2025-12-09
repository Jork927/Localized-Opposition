using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // References
    Rigidbody2D rb; // Reference to the Rigidbody2D component
    Vector2 movement; // Variable to store movement input

    // Variables
    public float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get references
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        float moveSpeedReal;

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            moveSpeedReal = moveSpeed / 2;
        }
        else
        {
            moveSpeedReal = moveSpeed;
        }

        // Execute movement
        rb.linearVelocity = movement * moveSpeedReal;
    }
}
