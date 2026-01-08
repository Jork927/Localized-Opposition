using Unity.Cinemachine;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject child;
    public GameObject emitter;
    public float horizontalSpeed;
    public float verticalSpeed;

    AudioSource audioSrc;
    public AudioClip shootSound;
    public int damageAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        //audioSrc.PlayOneShot(shootSound);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        emitter.transform.localScale = transform.localScale / 3;
        transform.Translate(horizontalSpeed * Time.deltaTime, verticalSpeed * Time.deltaTime, 0);
        child.transform.Rotate(0, 0, 720 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Damage player here
            GameObject.Find("Player").GetComponent<PlayerStats>().Damage(damageAmount);
            Destroy(gameObject);
        }
    }
}
