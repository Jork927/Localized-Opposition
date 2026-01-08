using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;

public class HomingBullet : MonoBehaviour
{
    public GameObject child;
    public GameObject emitter;
    GameObject target;
    Vector2 direction;
    public float speed;

    AudioSource audioSrc;
    public AudioClip shootSound;
    public int damageAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.Find("Player");
        direction = (target.transform.position - transform.position).normalized;
        audioSrc = GetComponent<AudioSource>();
        //audioSrc.PlayOneShot(shootSound);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        emitter.transform.localScale = transform.localScale / 3;
        transform.Translate(direction * speed * Time.deltaTime);
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
