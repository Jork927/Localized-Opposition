using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class NewMittensAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    public Vector3 offset = new(1, 0);
<<<<<<< HEAD
    private bool playerDetector = false;
    public float detectionRange = 10f;
=======
    public float chaseRange = 5f;

>>>>>>> 045a6a0b3633b0f276c0e3cecfd06153b6832923

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Start()
    {
        target = GameObject.Find("Player").transform;

    }

    private void Update()
    {
<<<<<<< HEAD
        if (target && playerDetector)
=======
        if (target&&Vector2.Distance(target.position, transform.position)<chaseRange)
>>>>>>> 045a6a0b3633b0f276c0e3cecfd06153b6832923
        {
            Vector3 direction = (target.position - (Vector3)transform.position + offset).normalized;
            moveDirection = direction;


        }
        if (Vector2.Distance(transform.position, target.position) < detectionRange)
        {
            playerDetector = true;

        }
        else
        {
            playerDetector = false;
            rb.linearVelocity = Vector2.zero;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Mittens has detected a collision.");
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("BattleTest");
            if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
            {
                Debug.Log("scene on " + SceneManager.GetActiveScene().buildIndex);
                Debug.Log("scene unlocked " + PlayerPrefs.GetInt("ReachedIndex"));



                PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex);
                PlayerPrefs.SetInt("unlockedLevels", SceneManager.GetActiveScene().buildIndex - 1);
                PlayerPrefs.Save();



                Debug.Log("scene on " + SceneManager.GetActiveScene().buildIndex);
                Debug.Log("scene unlocked " + PlayerPrefs.GetInt("ReachedIndex"));
            }
        }
    }

    private void FixedUpdate()
    {
<<<<<<< HEAD
        if (target && playerDetector)
=======
        if (target && Vector2.Distance(target.position, transform.position) < chaseRange)
>>>>>>> 045a6a0b3633b0f276c0e3cecfd06153b6832923
        {
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }
<<<<<<< HEAD
}
=======

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}


>>>>>>> 045a6a0b3633b0f276c0e3cecfd06153b6832923
