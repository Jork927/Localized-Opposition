using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Player Stats
    [Header("Player Stats")]
    public bool active;
    public int health;
    public bool invincible;
    public float invincibilityTime;
    float timeInvincible;

    public Color normalColor;
    public Color hurtColor;
    SpriteRenderer sr;

    // Sounds
    [Header("Sounds")]
    public AudioSource audioSrc;
    public AudioClip meow;
    public AudioClip hurtMeow;
    public AudioClip hurtHit;

    void Start()
    {
        timeInvincible = 0;
        sr = GetComponentInChildren<SpriteRenderer>();
        audioSrc = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (active)
        {
            switch (health
            )
            {
                case <= 0:
                    health = 0;

                    if (active)
                    {
                        audioSrc.PlayOneShot(hurtHit);
                    }

                    active = false;
                    Debug.Log("Player Defeated");
                    break;

                case > 100:
                    health = 100;
                    break;
            }

            // Invincibility
            if (invincible)
            {
                timeInvincible += Time.deltaTime;

                if (timeInvincible >= invincibilityTime)
                {
                    timeInvincible = 0;
                    invincible = false;
                }

                sr.color = Color.Lerp(hurtColor, normalColor, timeInvincible / invincibilityTime);
            }
            else
            {
                timeInvincible = 0;
                sr.color = normalColor;
            }
        }
    }

    public void Damage(int amount)
    {
        if (!invincible)
        {
            audioSrc.PlayOneShot(hurtMeow);
            audioSrc.pitch = Random.Range(0.75f, 1.25f);

            health -= amount;
            invincible = true;

            
        }
    }
}
