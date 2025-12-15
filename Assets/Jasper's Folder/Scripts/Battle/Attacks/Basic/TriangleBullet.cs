using Unity.Cinemachine;
using UnityEngine;

public class TriangleBullet : MonoBehaviour
{
    GameObject target;
    Vector2 direction;
    public float moveSpeed;
    public GameObject triangle;

    AudioSource audioSrc;
    public AudioClip shootSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.Find("Player");
        direction = (target.transform.position - transform.position).normalized;
        audioSrc = GetComponent<AudioSource>();
        audioSrc.PlayOneShot(shootSound);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        triangle.transform.Rotate(0, 0, 360 * (moveSpeed / 2) * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Damage player here
            GameObject.Find("Player").GetComponent<PlayerStats>().Damage(30);
            Destroy(gameObject);
        }
    }
}
