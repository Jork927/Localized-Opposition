using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Movement : MonoBehaviour
{
    public float speed = 0.5f;
    private Rigidbody2D rb;
    private Vector2 input;
    
    private Animator animator;
    public static Vector2 Lastpos;
    public static string currentScene;

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


        transform.position = Lastpos;
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

    }

    // Update is called once per frame - used for inputs and timers

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize(); // Makes the diagonal movement move the same as the other movements
                           // Without normalize, diagonal movement would be faste
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.position += new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

        animator.SetFloat("Horizontal", input.x);
        animator.SetFloat("Vertical", input.y);

    }

    // Called once per physics frame - used for physics (we'll use for our movement)

    private void LateUpdate()
    {
        rb.linearVelocity = input * speed;
    }
    private void OnDestroy()
    {
        Lastpos = transform.position;
    }
}
    

   
    
        
    

